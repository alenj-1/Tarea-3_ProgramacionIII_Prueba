namespace Pásalo.Models
{
    public static class OpcionesArticulo
    {
        public static IReadOnlyList<string> Categorias { get; } = Array.AsReadOnly(new[]
        {
            "Ropa y calzado",
            "Educación",
            "Tecnología",
            "Hogar",
            "Deportes",
            "Infantil",
            "Otros"
        });

        public static IReadOnlyList<string> Condiciones { get; } = Array.AsReadOnly(new[]
        {
            "Nuevo",
            "Como nuevo",
            "Buen estado"
        });
    }
}