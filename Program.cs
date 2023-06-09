using EspacioTarea;
internal class Program
{
    
    private static void Main(string[] args)
    {
        
        List <Tarea> tareasPendientes = new List <Tarea>(); //lista vacia
        List <Tarea> tareasRealizadas = new List <Tarea>();

        int op;
        string descripcion;
        Random aleatorio = new Random();
        do
        {
            do
            {
                System.Console.WriteLine("<><><><><><><><><><><><> MENU <><><><><><><><><><><><><>");
                System.Console.WriteLine("Seleccione una opcion: ");
                System.Console.WriteLine("0-Salir");
                System.Console.WriteLine("1-Cargar tareas");
                System.Console.WriteLine("2-Mostrar tareas pendientes");
                System.Console.WriteLine("3-Mover tareas");
                System.Console.WriteLine("4-Mostrar tareas realizadas");
                System.Console.WriteLine("5-Buscar tarea ");
                System.Console.WriteLine("6-Escribir datos ");
            } while (!int.TryParse(Console.ReadLine(),out op) || op < 0 || op > 6);
            switch (op)
            {
            case 1:
                cargarTareas(tareasPendientes); //paso x refercia para que se mantenga el contador de i
                break;
            case 2:
                System.Console.WriteLine("\n---------TAREAS PENDIENTES---------\n");
                mostrarTareas(tareasPendientes);
                break;

            case 3:
                moverTareas(tareasPendientes,tareasRealizadas);
                break;

            case 4:
                System.Console.WriteLine("\n---------TAREAS REALIZADAS---------\n");
                mostrarTareas(tareasRealizadas);
                break;

            case 5:
                System.Console.WriteLine("<<<< Busqueda de tareas pendientes >>>");
                System.Console.WriteLine("Ingrese la descripcion de la tarea: ");
                descripcion = Console.ReadLine();
                Tarea tarea = buscarTarea(descripcion,tareasPendientes);
                if (tarea != null)
                {
                    tarea.mostrarTarea();
                }
                else
                {
                    System.Console.WriteLine("No se encontro la tarea");
                }
                
                break;

            case 6:
                string actual = Directory.GetCurrentDirectory();
                File.Create(actual + @"\sumario.txt").Close();
                string[] lineas = {"Total horas de tareas realizadas: " + totalHoras(tareasRealizadas).ToString()};
                File.WriteAllLines(actual + @"\sumario.txt",lineas);
                break;

            }

        } while (op != 0);


    }

    /*########### Metodos ###########*/
    static void mostrarTareas(List<Tarea> tarea)
    {
        foreach (var item in tarea)
        {
            item.mostrarTarea();
            System.Console.WriteLine("\n");
        }
    }

    static void cargarTareas(List<Tarea> tareasPendientes)
    {
        int cantidadTareas;
        Random aleatorio = new Random();
        cantidadTareas = aleatorio.Next(1,5);
        int duracion=0;
        string descripcion;
        for (int i = 0; i < cantidadTareas; i++)
        {
            descripcion = "descripcion" + i;
            duracion = aleatorio.Next(10,101);
            Tarea tarea = new Tarea(i,descripcion,duracion);
            tareasPendientes.Add(tarea);
        }
    }

    static void moverTareas(List<Tarea> tareasPendientes,List<Tarea> tareasRealizadas)
    {
        int opcion;
        foreach (var item in tareasPendientes.ToList()) //ToList para que el foreach no de error cuando quito una tarea
        {
            do
            {
                System.Console.WriteLine("Desea mover la siguiente tarea ( Si (1) / No (0) ) ");
                item.mostrarTarea();
            } while (!int.TryParse(Console.ReadLine(),out opcion) || opcion < 0 || opcion > 1);
            if (opcion == 1 )
            {
                tareasRealizadas.Add(item);
                tareasPendientes.Remove(item);
            }
        }
    }

    //otra forma sin el ToList()
    static void moverTareas2(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas)
    {
        int opcion;
        for (int i = 0; i < tareasPendientes.Count; i++)
        {
            do
            {
                Console.WriteLine("Desea mover la siguiente tarea (Si (1) / No (0)): ");
                tareasPendientes[i].mostrarTarea();
            } while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 1);

            if (opcion == 1)
            {
                tareasRealizadas.Add(tareasPendientes[i]);
                tareasPendientes.RemoveAt(i);
                i--; //
            }
        }
    }


    static Tarea buscarTarea(string descripcion,List<Tarea> tarea)
    {
        foreach (var item in tarea)
        {
            if (item.Descripcion.IndexOf(descripcion) != -1)
            {
                return item;
            }
        }
        // si no se encuentra la tarea, siempre se debe devolver algo
        return null;
    }

    static int totalHoras(List<Tarea> tarea)
    {
        int suma=0;
        foreach (var item in tarea)
        {
            suma+=item.Duracion;
        }
        return suma;
    }
}
