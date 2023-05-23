using System;
using System.Collections.Generic;

public class RandomGenerator
{
    private Random random;

    public RandomGenerator()
    {
        random = new Random();
    }

    public List<int> GenerateDemands(int numberOfTrips)
    {
        List<int> demands = new List<int>();

        for (int i = 0; i < numberOfTrips; i++)
        {
            // Genera un número aleatorio para representar la cantidad requerida de artículos
            int demand = random.Next(1, 100); // Ajusta los valores mínimo y máximo según tus necesidades
            demands.Add(demand);
        }

        return demands;
    }

    public List<DateTime> GenerateDates(int numberOfTrips)
    {
        List<DateTime> dates = new List<DateTime>();

        for (int i = 0; i < numberOfTrips; i++)
        {
            // Genera una fecha aleatoria utilizando una distribución de Poisson
            DateTime startDate = new DateTime(2023, 1, 1); // Ajusta la fecha de inicio según tus necesidades
            int daysOffset = (int)Math.Round(PoissonDistribution(3)); // Ajusta el parámetro lambda según tus necesidades
            DateTime date = startDate.AddDays(daysOffset);
            dates.Add(date);
        }

        return dates;
    }

    private double PoissonDistribution(double lambda)
    {
        // Genera un número aleatorio utilizando una distribución de Poisson
        double L = Math.Exp(-lambda);
        double p = 1.0;
        int k = 0;

        do
        {
            k++;
            p *= random.NextDouble();
        } while (p > L);

        return k - 1;
    }
}

public class Program
{
    public static void Main()
    {
        RandomGenerator randomGenerator = new RandomGenerator();

        // Solicitar el número de viajes al usuario
        Console.Write("Ingrese el número de viajes: ");
        int numberOfTrips = int.Parse(Console.ReadLine());

        List<int> demands = randomGenerator.GenerateDemands(numberOfTrips);
        List<DateTime> dates = randomGenerator.GenerateDates(numberOfTrips);

        for (int i = 0; i < numberOfTrips; i++)
        {
            int demand = demands[i];
            DateTime date = dates[i];

            Console.WriteLine("Viaje " + (i + 1) + ": Demanda: " + demand + " | Fecha requerida: " + date.ToShortDateString());
        }

        // Puedes almacenar las listas 'demands' y 'dates' en las estructuras de datos necesarias de tu simulación

        // Resto del código para la asignación y secuenciación de los viajes
        // ...
    }
}
