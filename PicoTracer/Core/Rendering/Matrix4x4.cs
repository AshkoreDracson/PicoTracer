namespace PicoTracer
{
    public class Matrix4x4
    {
        public static Matrix4x4 TRS
        {
            get
            {
                return new Matrix4x4();
            }
        }

        private Vector4[] matrix;

        public double this[int x, int y]
        {
            get
            {
                return matrix[x][y];
            }
            set
            {
                matrix[x][y] = value;
            }
        }

        public Matrix4x4()
        {
            matrix = new Vector4[4]
            {
                Vector4.zero,
                Vector4.zero,
                Vector4.zero,
                Vector4.zero
            };
        }

        public Vector4 GetRow(int row)
        {
            return matrix[row];
        }
        public Vector4 GetColumn(int col)
        {
            return matrix[col];
        }

        public static explicit operator Matrix4x4(Vector4[] values)
        {
            Matrix4x4 cur = new Matrix4x4();

            if (values.GetLength(0) != 4 || values.GetLength(1) != 4)
                throw new InvalidMatrixSizeException();

            cur.matrix = values;
            return cur;
        }
    }
}