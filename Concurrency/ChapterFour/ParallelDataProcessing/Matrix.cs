namespace Concurrency.ChapterFour.ParallelDataProcessing;

public class Matrix(int rows, int columns)
{
    private double[,] _data = new double[rows, columns];

    public double this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    public void Rotate(double degrees)
    {
        var radians = Math.PI * degrees / 180.0;
        double[,] rotationMatrix = {
            { Math.Cos(radians), -Math.Sin(radians) },
            { Math.Sin(radians), Math.Cos(radians) }
        };

        Multiply(rotationMatrix);
    }

    public void Invert()
    {
        double determinant = GetDeterminant();
        if (determinant == 0)
        {
            throw new InvalidOperationException("Matrix is not invertible");
        }

        double[,] inverseMatrix = new double[_data.GetLength(0), _data.GetLength(1)];

        for (int i = 0; i < _data.GetLength(0); i++)
        {
            for (int j = 0; j < _data.GetLength(1); j++)
            {
                inverseMatrix[i, j] = _data[i, j] / determinant;
            }
        }

        _data = inverseMatrix;
    }

    private void Multiply(double[,] matrix)
    {
        int rows = _data.GetLength(0);
        int cols = _data.GetLength(1);

        if (matrix.GetLength(0) != cols || matrix.GetLength(1) != rows)
        {
            throw new InvalidOperationException("Invalid matrix dimensions for multiplication");
        }

        double[,] result = new double[rows, matrix.GetLength(1)];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int k = 0; k < cols; k++)
                {
                    result[i, j] += _data[i, k] * matrix[k, j];
                }
            }
        }

        _data = result;
    }

    private double GetDeterminant()
    {
        if (_data.GetLength(0) != _data.GetLength(1))
        {
            throw new InvalidOperationException("Determinant can only be calculated for square matrices");
        }

        int n = _data.GetLength(0);

        if (n == 2)
        {
            return _data[0, 0] * _data[1, 1] - _data[0, 1] * _data[1, 0];
        }

        double determinant = 0;

        for (int i = 0; i < n; i++)
        {
            determinant += Math.Pow(-1, i) * _data[0, i] * MinorMatrix(0, i).GetDeterminant();
        }

        return determinant;
    }

    private Matrix MinorMatrix(int rowToRemove, int colToRemove)
    {
        int rows = _data.GetLength(0) - 1;
        int cols = _data.GetLength(1) - 1;
        Matrix minor = new Matrix(rows, cols);

        for (int i = 0, newRow = 0; i < _data.GetLength(0); i++)
        {
            if (i == rowToRemove) continue;

            for (int j = 0, newCol = 0; j < _data.GetLength(1); j++)
            {
                if (j == colToRemove) continue;

                minor[newRow, newCol] = _data[i, j];
                newCol++;
            }

            newRow++;
        }

        return minor;
    }
    
    public bool IsInvertible()
    {
        return GetDeterminant() != 0;
    }
}