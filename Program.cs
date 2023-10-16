using System;

public class EditorGrafico{};

interface IGrafico
{
     public bool Mover(int x, int y);

     public void Dibujar();
}

public class Punto : IGrafico
{
    public int x {
        get {  return x; }
        set
        {
            if (value < 0)
            {
                x = 1;
            }
            else if (value > 800)
            {
                x = 800;
            }
            else x = value;
        }
    }

    public int y {
        get { return y; }
        set
        {
            if(value < 0)
            {
                y = 1;
            }
            else if (value > 600)
            {
                y = 600;
            }
            else y = value;
        } 
            }

    public Punto(int valorx, int valory)
    {
        x = valorx;
        y = valory;
    }

    public bool Mover(int x,int y)
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

   public void Dibujar() {

        System.Console.WriteLine("Punto \n X --> " + x + "\n Y --> " + y);

    }

   
}

public class Circulo : Punto
{
    public int radio
    {
        get { return radio; }
        set
        {
            if (value <= 0)
            {
                radio = 1;
            }
            else radio = value;
        }
    }
    
    public Circulo(int valorx, int valory, int valorradio):base(valorx,valory)
    {
        x = valorx;
        y = valory;
        radio = valorradio;
    }

    public bool Mover (int x, int y, int vradio)
    {
        if (x + vradio<0 || x + vradio > 800)
        {
            return false;
        }
        else if (y + vradio < 0 || y + radio > 600)
        {
            return false;
        }
        else return true;
    }

    public void Dibujar()
    {
        System.Console.WriteLine("CIRCULO \n X --> " + x + "\n Y --> " + y + "\n Radio --> " + radio);
    }
   
}

public class Rectangulo : Punto
{

   public Rectangulo(int valorx, int valory, int valoraltura, int valoranchura) : base(valorx, valory)
    {
        x=valorx;
        y=valory;
        altura = valoraltura;
        anchura = valoranchura;
    }
   
   public int altura
    {
        get { return altura; }
        set { 
            if (value < 10)
            {
                altura = 10;
            }
            else
                altura = value;
        }
    }
   public int anchura
    {
        get { return anchura; }
        set{
            if (value < 10)
            {
                anchura = 10;
            }
            else 
                anchura = value;
        }
    }

    public int x
    {
        get { return x; }
        set
        {
            if (value < 0)
            {
                x = 1;
            }
            else if (value > 800)
            {
                x = 800;
            }
            else x = value;
        }
    }

    public int y
    {
        get { return y; }
        set
        {
            if (value < 0)
            {
                y = 1;
            }
            else if (value > 600)
            {
                y = 600;
            }
            else y = value;
        }
    }

    public bool Mover(int x, int y, int alt, int anch)
    {
        if (x + (alt*anch)<0 || x + (alt*anch)>800 )
        {
            return false;
        }
        else if (y + (alt * anch) < 0 || y + (alt * anch) > 600)
        {
            return false;
        }
        else return true;
    }
    
    public void Dibujar()
    {
        System.Console.WriteLine("RECTANGULO \n X --> " + x + "\n Y --> " + y + "\n Altura --> " + altura + "\n Anchura --> " + anchura);

    }


}

class testcodigo
{
    static void Main(string[] args)
    {
        Punto punto = new Punto(800, 2211);
        punto.Dibujar();
        Circulo circulo = new Circulo(12, 120, 200);
        circulo.Dibujar();
        circulo.Mover(1, 2,2);
        Rectangulo rectangulo = new Rectangulo(92, 49, 20, 100);
        rectangulo.Dibujar();
    }

}