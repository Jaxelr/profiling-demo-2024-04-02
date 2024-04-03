namespace ProfileableApi.Services;

public class CpuService : IService
{
    public void Run() => Prime(500_000);

    private static int Prime(int n)
    {
        int primes = Enumerable.Range(2, int.MaxValue - 1)
            .Where(candidate => Enumerable.Range(2, (int)Math.Sqrt(candidate) - 1)
                .All(divisor => candidate % divisor != 0))
            .Take(n)
            .Last();

        return primes;
    }
}
