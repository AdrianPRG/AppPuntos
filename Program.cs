using System;
//FUNCION PARA CREAR EL PUNTO
static Punto CrearPunto()
{
    Console.WriteLine("CREACION DE PUNTO");
    Console.WriteLine("INTRODUZCA X");
    int xdepunto = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("INTRODUZCA Y");
    int ydepunto = Convert.ToInt32(Console.ReadLine());
    Punto puntonuevo = new Punto(xdepunto, ydepunto);
    return puntonuevo;
}

//FUNCION PARA CREAR CIRCULO
static Punto CrearCirculo()
{
    Console.WriteLine("CREACION DE CIRCULO");
    Console.WriteLine("INTRODUZCA X");
    int xdecirculo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("INTRODUZCA Y");
    int ydecirculo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("INTRODUZCA RADIO");
    int radiocirculo = Convert.ToInt32(Console.ReadLine());
    Circulo circulonuevo = new Circulo(xdecirculo, ydecirculo, radiocirculo);
    return circulonuevo;
}

//FUNCION PARA CREAR RECTANGULO
static Punto CrearRectangulo()
{
    Console.WriteLine("CREACION DE RECTANGULO");
    Console.WriteLine("INTRODUZCA X");
    int xderectangulo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("INTRODUZCA Y");
    int yderectangulo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("INTRODUZCA ANCHO");
    int ancho = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("INTRODUZCA ALTO");
    int alto = Convert.ToInt32(Console.ReadLine());
    Rectangulo rectangulonuevo = new Rectangulo(xderectangulo, yderectangulo, alto, ancho);
    return rectangulonuevo;
}


//PROGRAMA PRINCIPAL QUE LLAMA A LAS FUNCIONES PARA SOLICITAR LAS CREACIONES
static void Main()
{
    GraficoCompuesto graficoCompuesto = new GraficoCompuesto();
    graficoCompuesto.Añadir(CrearPunto());
    graficoCompuesto.Añadir(CrearCirculo());
    graficoCompuesto.Añadir(CrearRectangulo());
    Console.WriteLine("QUE DESEA (1) MOVER Y DIBUJAR // (2) SALIR");
    int accion = Convert.ToInt32(Console.ReadLine());
    if (accion==1)
    {
        graficoCompuesto.Mover(new Random().Next(0,800), new Random().Next(0,600));
        Console.WriteLine(graficoCompuesto.Dibujar());   
    }
    Console.WriteLine("FIN DEL PROGRAMA");
}

Main();


//CLASES


public class EditorGrafico { };

////////////////////////Interfaz Igrafico/////////////////////////
interface IGrafico
{
    public bool Mover(int x, int y);

    public string Dibujar();
}


/////////////////   CLASE PUNTO /////////////////////


public class Punto : IGrafico
{
    //Setters y getters de la X

    private int _x;

    public int X
    {
        get { return _x; }
        set
        {
            if (value > 800 || value < 0)
            {
                throw new Exception("X NO PUEDE SER MAYOR A 800 NI MENOR A 0!");
            }

            _x = value;
        }
    }

    //Setters y getters de la Y

    private int _y;

    public int Y
    {
        get { return _y; }
        set
        {
            if (value > 600 || value < 0)
            {
                throw new Exception("LA Y NO PUEDE SER MAYOR A 600 NI MENOR A 0!");
            }

            _y = value;
        }
    }

    //constructor
    public Punto(int valorx, int valory)
    {
        X = valorx;
        Y = valory;
    }

    //funcion mover con codigo
    //Una clase que implemente una interfaz no tiene que hacer override de las funciones de la interfaz pues ya esta implementada
    //virtual es para que los de abajo lo puedan heredar
    //override es de clase a clase

    public virtual bool Mover(int x, int y)
    {
        if (x < 0 || x > 800 || y < 0 || y > 600)
        {
            return false;
        }

        return true;
    }

    //funcion Dibujar devuelve string
    public virtual string Dibujar()
    {
        return $"PUNTO --> X -> {X} Y -> {Y}";
    }
}


/////////////////   CLASE CIRCULO /////////////////////


public class Circulo : Punto
{
    //setters y getters de radio

    private double _radio;

    public double Radio
    {
        get { return _radio; }
        set {
            if (X - value  < 0 || X + value > 800 || Y - value < 0 || Y + value > 600)
            {
                throw new Exception("EL CIRCULO NO PUEDE SUPERAR LOS VALORES ESTABLECIDOS!");
            }

            _radio = value;
        }
    }

    //constructor de circulo
    public Circulo(int valorx, int valory, int valorradio) : base(valorx, valory)
    {
        X = valorx;
        Y = valory;
        Radio = valorradio;
    }

    //fun override de Mover, con distinto codigo
    public override bool Mover(int x, int y)
    {
        if (x - _radio < 0 || x + _radio > 800 || y - _radio < 0 || y + _radio > 600)
        {
            return false;
        }

        return true;
    }

    //fun override de Dibujar con codigo disntinto adaptado a circulo
    public override string Dibujar()
    {
        return $"CIRCULO --> X -> {X} Y -> {Y} radio -> {Radio} ";
    }
}


/////////////////   CLASE RECTANGULO  /////////////////////


public class Rectangulo : Punto
{
    //setters y getters

    private double _altura;

    public double Altura
    {
        get { return _altura; }
        set
        {
            if (Y - value / 2 < 0 || Y + value / 2 > 600)
            {
                throw new Exception("LA ALTURA NO PUEDE SOBREPASAR LOS LIMITES!: 600 MAX 0 MIN");
            }

            _altura = value;
        }
    }

    private double _anchura;

    //setters y getters
    public double Anchura
    {
        get { return _anchura; }
        set
        {
            if ( X - value / 2 < 0 || X + value / 2 > 800)
            {
                throw new Exception("LA ANCHURA NO PUEDE SOBREPASAR LOS LIMITES!!: 800 MAX 0 MIN");
            }

            _anchura = value;
        }
    }

    //constructor rectangulo
    public Rectangulo(int valorx, int valory, int valoraltura, int valoranchura) : base(valorx, valory)
    {
        X = valorx;
        Y = valory;
        Altura = valoraltura;
        Anchura = valoranchura;
    }

    //fun override de mover con distinto codigo
    public override bool Mover(int x, int y)
    {
        if (x - Anchura / 2 < 0 || x + Anchura / 2 > 800 || y - Altura / 2 < 0 || y + Altura / 2 > 600)
        {
            return false;
        }
        return true;
    }

    //fun override de Dibujar con codigo adaptado
    public override string Dibujar()
    {
        return $"RECTANGULO --> X -> {X} Y -> {Y} Altura -> {Altura} Anchura -> {Anchura}";
    }
}

/////////////////   CLASE GRAFICOCOMPUESTO /////////////////////


class GraficoCompuesto : IGrafico
{
    //Lista privada
    private List<IGrafico> _lista = new List<IGrafico>();

    //Funcion para añadir graficos
    public void Añadir(IGrafico grafico)
    {
        _lista.Add(grafico);
    }

    public bool Mover(int x, int y)
    {
        bool nohayerror = true;
        
        foreach (var igrafico in _lista)
        {
            if (igrafico.Mover(x,y)==false)
            {
                nohayerror = false;
            }
        }
        return nohayerror;
    }

    public string Dibujar()
    {
        string dibujardeigraficos = "";
        foreach (var igrafico in _lista)
        {
            dibujardeigraficos += igrafico.Dibujar() + "\n";
        }

        return dibujardeigraficos;
    }
}