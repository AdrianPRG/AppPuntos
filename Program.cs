using System;
GraficoCompuesto GraficoCOM = new GraficoCompuesto();
        
Punto punto = new Punto(800, 2211);
punto.Dibujar();
Circulo circulo = new Circulo(12, 120, 200);
circulo.Dibujar();
circulo.Mover(1, 2);
Rectangulo rectangulo = new Rectangulo(92, 49, 20, 100);
rectangulo.Dibujar();
rectangulo.Mover(300, 010);

GraficoCOM.añadir(punto);
GraficoCOM.añadir(circulo);
GraficoCOM.añadir(rectangulo);
        
GraficoCOM.mostrar();
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
    public virtual bool Mover(int x,int y)
    {
        if (x<0 || x>800)
        {
            return false;
        }
        else if (y<0 || y>600)
        {
            return false;
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
        if (x + radio < 0 || x + radio > 800 && y + radio < 0 || y + radio > 600)
        {
            return false;
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
        if (x + anchura < 0 || x + anchura > 800 && y + altura < 0 || y + altura > 600)
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