namespace ProyectoLasagna
{
    public class Lasagna
    {
                public int MinutosEsperadosEnElHorno()
        {
            return 40;
        }

        
        public int MinutosRestantesEnElHorno(int minutosActualesEnElHorno)
        {
            return MinutosEsperadosEnElHorno() - minutosActualesEnElHorno;
        }

    
        public int TiempoDePreparacionEnMinutos(int numeroDeCapas)
        {
            return numeroDeCapas * 2;
        }

        
        public int TiempoTranscurridoEnMinutos(int numeroDeCapas, int minutosActualesEnElHorno)
        {
            int tiempoDePreparacion = TiempoDePreparacionEnMinutos(numeroDeCapas);
            return tiempoDePreparacion + minutosActualesEnElHorno;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var lasagna = new Lasagna();
            Console.WriteLine(lasagna.MinutosEsperadosEnElHorno()); // => 40
            Console.WriteLine(lasagna.MinutosRestantesEnElHorno(30)); // => 10
            Console.WriteLine(lasagna.TiempoDePreparacionEnMinutos(2)); // => 4
            Console.WriteLine(lasagna.TiempoTranscurridoEnMinutos(3, 20)); // => 26
        }
    }
}

