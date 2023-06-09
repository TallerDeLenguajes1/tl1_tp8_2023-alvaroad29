using EspacioTarea;
internal class Program
{
    
    private static void Main(string[] args)
    {
        
        List <Tarea> tareasPendientes = new List <Tarea>(); //lista vacia
        List <Tarea> tareasRealizadas = new List <Tarea>();

        int op,duracion=0,opcion2,cantidadTareas,j;
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
            } while (!int.TryParse(Console.ReadLine(),out op) || op < 0 || op > 5);
            switch (op)
            {
            case 1:
                System.Console.WriteLine("<<<< cantidad de tareas: >>>");   
                do
                {
                    //System.Console.WriteLine("Desea crear otra tarea ( Si (1) / No (0) ): ");
                } while (!int.TryParse(Console.ReadLine(),out cantidadTareas));

                for (int i = 0; i < cantidadTareas; i++)
                {
                    descripcion = "descripcion" + i;
                    duracion = aleatorio.Next(10,101);
                    Tarea tarea = new Tarea(i,descripcion,duracion);

                    tareasPendientes.Add(tarea);
                }
                break;
            case 2:
                System.Console.WriteLine("\n---------TAREAS PENDIENTES---------\n");
                mostrarTareas(tareasPendientes);
                break;

            case 3:
                cantidadTareas = tareasPendientes.Count;
                for ( j = 0; j < cantidadTareas; j++)
                {
                    do
                    {
                        System.Console.WriteLine("Desea mover la siguiente tarea ( Si (1) / No (0) ) ");
                        tareasPendientes[j].mostrarTarea();
                    } while (!int.TryParse(Console.ReadLine(),out opcion2) || opcion2 < 0 || opcion2 > 1);

                    if (opcion2 == 1 )
                    {
                        tareasRealizadas.Add(tareasPendientes[j]);
                        tareasPendientes.RemoveAt(j);
                        cantidadTareas--;
                    }
                }
                break;

            case 4:
                System.Console.WriteLine("\n---------TAREAS REALIZADAS---------\n");
                mostrarTareas(tareasRealizadas);
                break;

            case 5:
                System.Console.WriteLine("<<<< Busqueda de tareas pendientes >>>");
                System.Console.WriteLine("Ingrese la descripcion de la tarea: ");
                descripcion = Console.ReadLine();
                Tarea tarea1 = buscarTarea(descripcion,tareasPendientes);
                tarea1.mostrarTarea();
                break;

            }

        } while (op != 0);


    }

    static void mostrarTareas(List<Tarea> tarea)
    {
        foreach (var item in tarea)
        {
            item.mostrarTarea();
            System.Console.WriteLine("\n");
        }
    }

    static Tarea buscarTarea(string descripcion,List<Tarea> tarea)
    {
        Tarea a = new Tarea();
        foreach (var item in tarea)
        {
            if (item.Descripcion.IndexOf(descripcion) != -1)
            {
                a = item;
            }
        }
        return a;
    }
}
