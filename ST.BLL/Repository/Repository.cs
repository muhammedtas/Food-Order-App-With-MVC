using ST.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.BLL.Repository
{
  public  class Repository
    {
        public class AdresRepo : RepositoryBase<Adres, int> { }
        public class FirmaRepo : RepositoryBase<Firma, int> { }
        public class FirmaUrunRepo : RepositoryBase<FirmaUrun,int> { }
        public class OdemeTipiRepo : RepositoryBase<OdemeTipi,int> { }
        public class SiparisRepo: RepositoryBase<Siparis,int> { }
        public class SiparisDetayRepo : RepositoryBase<SiparisDetay, int> { }
        public class UrunRepo : RepositoryBase<Urun,int> { }
        public class UrunKategoriRepo : RepositoryBase<UrunKategori, int> { }
    }
}
