using System;
/**
GraficoCompuesto GraficoCOM = new GraficoCompuesto();
Punto punto = new Punto(600, 50);
Console.WriteLine(punto.Dibujar());
punto.Mover(3, 45);
Circulo circulo = new Circulo(12, 120, 200);
Console.WriteLine(circulo.Dibujar());
circulo.Mover(1, 2);
Rectangulo rectangulo = new Rectangulo(92, 49, 20, 100);
Console.WriteLine(rectangulo.Dibujar());
rectangulo.Mover(300, 010);

GraficoCOM.añadir(punto);
GraficoCOM.añadir(circulo);
GraficoCOM.añadir(rectangulo);

GraficoCOM.mostrar();
*/

static void imprimeono(Punto punto)
{
    Console.WriteLine("DESEA SALIR (1) O DIBUJAR LA FIGURA (2)");
    int quedesea = Convert.ToInt32(Console.ReadLine());
    switch (quedesea)
    {
        case 1:
            punto.Dibujar();
            break;
        case 2:
            break;
    }
}

static void main()
{
    bool continuar = true;
    while (continuar!=false)
    {
        Console.WriteLine("QUE DESEA CREAR \n 1 -> PUNTO \n 2 -> CIRCULO \n 3 -> RECTANGULO");
        int opcion = Convert.ToInt32(Console.ReadLine());
        
        switch (opcion)
        {
            case 1:
                
                Console.WriteLine("INTRODUZCA X");
                int xdepunto = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("INTRODUZCA Y");
                int ydepunto = Convert.ToInt32(Console.ReadLine());
                Punto puntonuevo = new Punto(xdepunto, ydepunto);
                puntonuevo.Mover(xdepunto, ydepunto);
                imprimeono(puntonuevo);
                break;
            case 2:
                Console.WriteLine("INTRODUZCA X");
                int xdecirculo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("INTRODUZCA Y");
                int ydecirculo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("INTRODUZCA RADIO");
                int radiocirculo = Convert.ToInt32(Console.ReadLine());
                Circulo circulonuevo = new Circulo(xdecirculo, ydecirculo,radiocirculo);
                circulonuevo.Mover(xdecirculo, ydecirculo);
                imprimeono(circulonuevo);
                break;
            case 3:
                Console.WriteLine("INTRODUZCA X");
                int xderectangulo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("INTRODUZCA Y");
                int yderectangulo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("INTRODUZCA ANCHO");
                int ancho = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("INTRODUZCA ALTO");
                int alto = Convert.ToInt32(Console.ReadLine());
                Rectangulo rectangulonuevo = new Rectangulo(xderectangulo, yderectangulo,ancho,alto);
                rectangulonuevo.Mover(xderectangulo, yderectangulo);
                imprimeono(rectangulonuevo);
                break;
            case 4:
                continuar = false;
                Console.WriteLine("PROGRAMA FINALIZADO");
                break;
        } 
    }
}

main();


//CLASES



public class EditorGrafico{};

//Interfaz Igrafico
interface IGrafico
{
     public bool Mover(int x, int y);

     public string Dibujar();
}

public class Punto : IGrafico
{
    
    //Setters y getters
    public int x { get; set; }

    //Setters y getters
    public int y { get; set; }

    //constructor
    public Punto(int valorx, int valory)
    {
        x = valorx;
        y = valory;
    }

    //funcion mover con codigo
    //Una clase que implemente una interfaz no tiene que hacer override de las funciones de la interfaz pues ya esta implementada
    //virtual es para que los de abajo lo puedan heredar
    //override es de clase a clase
    public virtual bool Mover(int x,int y)
    {
        if (x<0 || x>800)
        {
            throw new Exception("X FUERA DE RANGO");
        }
        else if (y<0 || y>600)
        {
            throw new Exception("Y FUERA DE RANGO");;
        }
        else return true;
    }

    //funcion Dibujar devuelve string
    public virtual string Dibujar()
    {
        return $"Punto --> X -> {x} Y -> {y}";
    }

   
}

public class Circulo : Punto
{
    //setters y getters de rario
    public int radio { get; set; }
    
    //constructor de circulo
    public Circulo(int valorx, int valory, int valorradio):base(valorx,valory)
    {
        x = valorx;
        y = valory;
        radio = valorradio;
    }

    //fun override de Mover, con distinto codigo
    public override bool Mover(int x, int y)
    {
        if (x - radio < 0 || x + radio > 800 || y - radio < 0 || y + radio > 600)
        {
            throw new Exception("SE PASA DE LO PERMITIDO");
        }
        else return true;
    }
    
    //fun override de Dibujar con codigo añadido
    public override string Dibujar()
    {
        return base.Dibujar() + $" radio -> {radio}";
    }
}

public class Rectangulo : Punto
{
    //setters y getters
   public int altura { get; set; }
   //setters y getters
   public int anchura { get; set; }
    //constructor rectangulo
    public Rectangulo(int valorx, int valory, int valoraltura, int valoranchura) : base(valorx, valory)
    {
        x=valorx;
        y=valory;
        altura = valoraltura;
        anchura = valoranchura;
    }
    
    //fun override de mover con distinto codigo
    public override bool Mover(int x, int y)
    {
        if (x - anchura/2 < 0 || x + anchura/2 > 800 || y - altura/2 < 0 || y + altura/2 > 600)
        {
            return false;
        }
        else return true;
    }

    //fun override de Dibujar con mas codigo añadido
    public override string Dibujar()
    {
        return base.Dibujar() + $" Altura -> {altura} Anchura -> {anchura}";
    }
}

class GraficoCompuesto
{
    //Lista privada
    private List<IGrafico> lista = new List<IGrafico>();

    //Funcion para añadir graficos
    public void añadir(IGrafico grafico)
    {
        lista.Add(grafico);
    }

    //mostrar todos los graficos
    public void mostrar()
    {
        foreach (var i in lista)
        {
            i.Dibujar();
        }
    }

}