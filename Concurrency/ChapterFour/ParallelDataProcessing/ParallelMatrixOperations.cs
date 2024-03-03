namespace Concurrency.ChapterFour.ParallelDataProcessing;

public class ParallelMatrixOperations
{
    // Метод Rotate без возможности отмены
    public void RotateMatrices(IEnumerable<Matrix> matrices, double degrees)
    {
        Parallel.ForEach(matrices, matrix => matrix.Rotate(degrees));
    }
    
    // Метод Rotate с возможностью отмены цикла снаружи с помощью cancellation token'а
    public void RotateMatrices(IEnumerable<Matrix> matrices, double degrees, CancellationToken cancellationToken)
    {
        Parallel.ForEach(
            matrices,
            new ParallelOptions { CancellationToken = cancellationToken },
            matrix => matrix.Rotate(degrees));
    }

    // Метод Invert с отменой цикла в случае если матрица необратима (детерминат равен нулю)
    public void InvertMatrices(IEnumerable<Matrix> matrices)
    {
        Parallel.ForEach(matrices, (matrix, state) =>
        {
            if (matrix.IsInvertible())
            {
                matrix.Invert();
            }
            else
            {
                // Если матрица необратима, цикл прерывается (может оказаться, что другие матрицы уже параллельно обрабатываются)
                state.Stop();
            }
        });
    }

    // Метод параллельного получения обратных матриц с подсчётом количества обратимых
    // С помощью lock результирующая переменная защищена от одновременного изменения из нескольких потоков  
    public int GetInvertedMatricesCount(IEnumerable<Matrix> matrices)
    {
        var lockObject = new object();
        var nonInvertibleMatricesCount = 0;

        Parallel.ForEach(matrices, matrix =>
        {
            if (matrix.IsInvertible())
            {
                matrix.Invert();
            }
            else
            {
                lock (lockObject)
                {
                    // Общее для всех потоков состояние защищено с помощью lock
                    nonInvertibleMatricesCount++;
                }
            }
        });

        return nonInvertibleMatricesCount;
    }
}