using ArgumentException = System.ArgumentException;

namespace ClassWork_C_38.Medicine;

public class MedicineService: IMedicineService
{
    private List<Medicine> _medicines;

    public MedicineService()
    {
        _medicines = new List<Medicine>();
    }
    
    public Medicine Create(Medicine medicine)
    {
        _medicines.Add(medicine);
        return medicine;
    }

    public List<Medicine> Get()
    {
        return _medicines;
    }

    public Medicine Get(long id)
    {
        var result = _medicines.FirstOrDefault(medicine => medicine.Id == id);
        
        if (result is null)
            throw new ArgumentException("Medicine by this id does not exist!");
        
        return result;
    }

    public Medicine Update(Medicine medication)
    {
        var medicineToUpdate = _medicines.FirstOrDefault(drug => drug.Id == medication.Id);
        
        if (medicineToUpdate is null)
            throw new ArgumentException("Medicine to update is not found!");
        
        medicineToUpdate.Id = medication.Id;
        medicineToUpdate.Name = medication.Name;
        medicineToUpdate.Price = medication.Price;
        medicineToUpdate.Description = medication.Description;
        medicineToUpdate.ExpirationDate = medication.ExpirationDate;
        medicineToUpdate.LeftCount = medication.LeftCount;
        medicineToUpdate.UpdatedAt = DateTime.Now;
        
        return medicineToUpdate;
    }

    public bool Delete(long medicineId)
    {
        throw new NotImplementedException();
    }
}