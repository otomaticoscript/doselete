namespace Doselete.Domain.Entity
{
    public class Enums
    {
        public enum FieldTypes
        {
            Boolean = 1,
            Numerico = 2,
            Texto = 3,
            Seleccion = 4,
            SeleccionMultiple = 5,
            Recurso = 6
            //Fecha = ?,
            //Enlace = ?
        }
        /* 
         * Para Mejoras del Template -- establecer tipo de Template pàra saber con mas claridad
         * quien es Producto(RAIZ), quien es Estructura(Ramas o Hojas) y quien es "List" (Ramas)
        public enum TemplateTypes
        {
            Product,
            Structure,
            List
        }
        */
    }
}
