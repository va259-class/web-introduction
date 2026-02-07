using Vektorel.BasicDataBinding.Models;

namespace Vektorel.BasicDataBinding.Managers;

public class CompanyManager
{
    public List<Company> GetCompanies()
    {
        return new List<Company>
        {
            new Company
            {
                Id = 1,
                Name = "Can Nakliyat",
                Contact = "+903125554433",
                Country = "Türkiye",
                FoundedAt = 2007,
                FlagCode = "tr"
            },
            new Company
            {
                Id = 2,
                Name = "Flutgendicht",
                Contact = "+495443665500",
                Country = "Almanya",
                FoundedAt = 2011,
                FlagCode = "de"
            },
            new Company
            {
                Id = 3,
                Name = "Şah Mendoon",
                Contact = "+98755441010",
                Country = "İran",
                FoundedAt = 2013,
                FlagCode = "ir"
            },
            new Company
            {
                Id = 4,
                Name = "Kazbeku Coo.",
                Contact = "+98755441010",
                Country = "Gürcistan",
                FoundedAt = 2016,
                FlagCode = "ge"
            },
            new Company
            {
                Id = 5,
                Name = "Yıldızlar Nakliye",
                Contact = "+902125664780",
                Country = "Türkiye",
                FoundedAt = 2015,
                FlagCode = "tr"
            }
        };
    }
}
