using System.Diagnostics.CodeAnalysis;
using N42_C.Models;

namespace N42_C.Services;

public class FuelStationService
{
    private readonly FuelFillerService _fuelFillerService;
    private static SemaphoreSlim _semaphore;
    public FuelStationService(FuelFillerService fuelFillerService)
    {
        _fuelFillerService = fuelFillerService;
    }

    [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
    public async ValueTask<int> Start(List<Car> cars)
    {
        _semaphore = new SemaphoreSlim(10, 100);
        var fillTasks = cars.Select(car =>
        {
            return Task.Run(() =>
            {
                return _fuelFillerService.Fill(car);
            });
        });

        var balance = await Task.WhenAll(fillTasks);
        return balance.Sum();
    }
}