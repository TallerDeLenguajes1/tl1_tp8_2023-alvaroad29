namespace EspacioTarea
{
    public class Tarea
    {
        private int tareaId;
        private string  descripcion;
        private int duracion;

        public Tarea(int tareaId,string descripcion,int duracion)
        {
            this.tareaId = tareaId;
            this.descripcion = descripcion;
            this.duracion = duracion;
        }

        public Tarea()
        {
        }

        public int TareaId { get => tareaId; set => tareaId = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        //metodos

        public void mostrarTarea()
        {
            System.Console.WriteLine($"Tarea ID: {tareaId}");
            System.Console.WriteLine($"Tarea descripcion: {descripcion}");
            System.Console.WriteLine($"Tarea duracion: {duracion}");
        }
    }
}

