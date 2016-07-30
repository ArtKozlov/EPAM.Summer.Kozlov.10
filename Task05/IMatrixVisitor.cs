
namespace Task05 {
    public interface IMatrixVisitor<T> {
        void Visit(SquareMatrix<T> matrix, AbstractMatrix<T> addMatrix);
        void Visit(SymmetricMatrix<T> matrix, AbstractMatrix<T> addMatrix);
        void Visit(DiagonalMatrix<T> matrix, AbstractMatrix<T> addMatrix);
    }
}
