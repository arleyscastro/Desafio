namespace App.Domain.Interface.Service
{
    public interface IValidatorService
    {
        bool IsCNPJValid(string cnpj);
    }
}
