namespace ClassWork_C_38.Medicine;

public interface IMedicineService
{
    public Medicine Create(Medicine medicine);
    public List<Medicine> Get();
    public Medicine Get(long id);
    public Medicine Update(Medicine Medicine);
    public bool Delete(long medicineId);
}