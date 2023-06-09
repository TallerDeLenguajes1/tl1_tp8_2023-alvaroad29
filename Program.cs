//using EspacioTarea;
internal class Program
{
    
    private static void Main(string[] args)
    {
        System.Console.WriteLine("Ingrese la direccion de una carpeta");
        string path = Console.ReadLine();
        var archivos = new List<string>();
        string nombre;
        System.Console.WriteLine($"<<<< Listas de archivos en la ubicacion: {path} >>>>");
        foreach (var archivo in Directory.GetFiles(path))
        {
            nombre = archivo.ToString().Split(@"\").Last();
            System.Console.WriteLine(nombre);
            archivos.Add(nombre);
        }

        int i=1;
        using (StreamWriter archivo = new StreamWriter("index.csv")) //using libera el archivo despues de usarlo
        {
            foreach (var item in archivos)
            {
                archivo.WriteLine($"{i}, {item.Split('.')[0]}, {item.Split('.').Last()}");
                i++;
            }
        }

    }
}
