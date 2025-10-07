// src/UserCRUD.Domain/Entities/User.cs

using System.Text.RegularExpressions;

namespace UserCRUD.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Gender { get; private set; }
    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string PropertyNumber { get; private set; }

    // Construtor usado para criar um novo usuário. A validação ocorre aqui.
    public User(string fullName, string gender, string cpf, string email, string phoneNumber, string country, string state, string zipCode, string city, string street, string propertyNumber)
    {
        // Validações
        ValidateCpf(cpf);
        ValidatePhoneNumber(phoneNumber);
        ValidateZipCode(zipCode);
        ValidatePropertyNumber(propertyNumber);
        // Outras validações podem ser adicionadas aqui (ex: email, nome)

        Id = Guid.NewGuid(); // Gera um ID único para cada novo usuário
        FullName = fullName;
        Gender = gender;
        Cpf = cpf;
        Email = email;
        PhoneNumber = phoneNumber;
        Country = country;
        State = state;
        ZipCode = zipCode;
        City = city;
        Street = street;
        PropertyNumber = propertyNumber;
    }

    // Métodos de validação privados
    private void ValidateCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf) || !Regex.IsMatch(cpf, @"^\d{11}$"))
        {
            throw new ArgumentException("CPF inválido. Deve conter exatamente 11 dígitos numéricos.", nameof(cpf));
        }
    }

    private void ValidatePhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber) || !Regex.IsMatch(phoneNumber, @"^\d{10,11}$"))
        {
            throw new ArgumentException("Telefone inválido. Deve conter 10 ou 11 dígitos numéricos (com DDD).", nameof(phoneNumber));
        }
    }

    private void ValidateZipCode(string zipCode)
    {
        if (string.IsNullOrWhiteSpace(zipCode) || !Regex.IsMatch(zipCode, @"^\d{8}$"))
        {
            throw new ArgumentException("CEP inválido. Deve conter exatamente 8 dígitos numéricos.", nameof(zipCode));
        }
    }

    private void ValidatePropertyNumber(string propertyNumber)
    {
        if (string.IsNullOrWhiteSpace(propertyNumber) || !propertyNumber.All(char.IsDigit))
        {
            throw new ArgumentException("Número do imóvel inválido. Deve conter apenas números.", nameof(propertyNumber));
        }
    }
}