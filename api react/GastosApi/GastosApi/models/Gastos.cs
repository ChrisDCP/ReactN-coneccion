namespace GastosApi.models
{
    public class Gastos
    {

        public int GastoID { get; set; }
        public string Descripcion { get; set; }
        public float Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int UserID { get; set; }
        
    }
}
