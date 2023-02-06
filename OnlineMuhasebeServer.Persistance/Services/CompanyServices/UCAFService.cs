using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.UCAFRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.CompanyServices
{
    public sealed class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IUCAFQueryRepository _queryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper, IUCAFQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _queryRepository = queryRepository;
        }

        public async Task CreateMainUcafsToCompanyAsync(string companyId, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _queryRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);

            var oldList = await _queryRepository.GetWhere(p=> p.Type == 'A').ToListAsync();
            _commandRepository.RemoveRange(oldList);            

            List<UniformChartOfAccount> uniformChartOfAccounts = new List<UniformChartOfAccount>();

            UniformChartOfAccount ucaf1 = new();
            ucaf1.Code = "1";
            ucaf1.Name = "DÖNEN VARLIKLAR";
            ucaf1.Type = 'A';
            ucaf1.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf1);

            UniformChartOfAccount ucaf2 = new();
            ucaf2.Code = "10";
            ucaf2.Name = "HAZIR DEĞERLER";
            ucaf2.Type = 'A';
            ucaf2.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf2);

            UniformChartOfAccount ucaf3 = new();
            ucaf3.Code = "100";
            ucaf3.Name = "KASA";
            ucaf3.Type = 'A';
            ucaf3.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf3);

            UniformChartOfAccount ucaf4 = new();
            ucaf4.Code = "101";
            ucaf4.Name = "ALINAN ÇEKLER";
            ucaf4.Type = 'A';
            ucaf4.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf4);

            UniformChartOfAccount ucaf5 = new();
            ucaf5.Code = "102";
            ucaf5.Name = "BANKALAR";
            ucaf5.Type = 'A';
            ucaf5.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf5);

            UniformChartOfAccount ucaf6 = new();
            ucaf6.Code = "103";
            ucaf6.Name = "VERİLEN ÇEKLER VE ÖDEME EMİRLERİ (-)";
            ucaf6.Type = 'A';
            ucaf6.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf6);

            UniformChartOfAccount ucaf7 = new();
            ucaf7.Code = "108";
            ucaf7.Name = "DİĞER HAZIR DEĞERLER";
            ucaf7.Type = 'A';
            ucaf7.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf7);

            UniformChartOfAccount ucaf8 = new();
            ucaf8.Code = "11";
            ucaf8.Name = "MENKUL KIYMETLER";
            ucaf8.Type = 'A';
            ucaf8.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf8);

            UniformChartOfAccount ucaf9 = new();
            ucaf9.Code = "110";
            ucaf9.Name = "HİSSE SENETLERİ";
            ucaf9.Type = 'A';
            ucaf9.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf9);

            UniformChartOfAccount ucaf10 = new();
            ucaf10.Code = "111";
            ucaf10.Name = "ÖZEL KESİM TAHVİL, SENET VE BONOLARI";
            ucaf10.Type = 'A';
            ucaf10.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf10);

            UniformChartOfAccount ucaf11 = new();
            ucaf11.Code = "112";
            ucaf11.Name = "KAMU KESİMİ TAHVİL, SENET VE BONOLARI";
            ucaf11.Type = 'A';
            ucaf11.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf11);

            UniformChartOfAccount ucaf12 = new();
            ucaf12.Code = "118";
            ucaf12.Name = "DİĞER MENKUL KIYMETLER";
            ucaf12.Type = 'A';
            ucaf12.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf12);

            UniformChartOfAccount ucaf13 = new();
            ucaf13.Code = "119";
            ucaf13.Name = "MENKUL KIYMETLER DEĞER DÜŞÜKLÜĞÜ KARŞILIĞI (-)";
            ucaf13.Type = 'A';
            ucaf13.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf13);

            UniformChartOfAccount ucaf14 = new();
            ucaf14.Code = "12";
            ucaf14.Name = "TİCARİ ALACAKLAR";
            ucaf14.Type = 'A';
            ucaf14.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf14);

            UniformChartOfAccount ucaf15 = new();
            ucaf15.Code = "120";
            ucaf15.Name = "ALICILAR";
            ucaf15.Type = 'A';
            ucaf15.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf15);

            UniformChartOfAccount ucaf16 = new();
            ucaf16.Code = "121";
            ucaf16.Name = "ALACAK SENETLERİ";
            ucaf16.Type = 'A';
            ucaf16.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf16);

            UniformChartOfAccount ucaf17 = new();
            ucaf17.Code = "122";
            ucaf17.Name = "ALACAK SENETLERİ REESKONTU (-)";
            ucaf17.Type = 'A';
            ucaf17.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf17);

            UniformChartOfAccount ucaf18 = new();
            ucaf18.Code = "126";
            ucaf18.Name = "VERİLEN DEPOZİTO VE TEMİNATLAR";
            ucaf18.Type = 'A';
            ucaf18.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf18);

            UniformChartOfAccount ucaf19 = new();
            ucaf19.Code = "128";
            ucaf19.Name = "ŞÜPHELİ TİCARİ ALACAKLAR";
            ucaf19.Type = 'A';
            ucaf19.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf19);

            UniformChartOfAccount ucaf20 = new();
            ucaf20.Code = "129";
            ucaf20.Name = "ŞÜPHELİ TİCARİ ALACAKLAR KARŞILIĞI (-)";
            ucaf20.Type = 'A';
            ucaf20.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf20);

            UniformChartOfAccount ucaf21 = new();
            ucaf21.Code = "13";
            ucaf21.Name = "DİĞER ALACAKLAR";
            ucaf21.Type = 'A';
            ucaf21.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf21);

            UniformChartOfAccount ucaf22 = new();
            ucaf22.Code = "131";
            ucaf22.Name = "ORTAKLARDAN ALACAKLAR";
            ucaf22.Type = 'A';
            ucaf22.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf22);

            UniformChartOfAccount ucaf23 = new();
            ucaf23.Code = "132";
            ucaf23.Name = "İŞTİRAKLERDEN ALACAKLAR";
            ucaf23.Type = 'A';
            ucaf23.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf23);

            UniformChartOfAccount ucaf24 = new();
            ucaf24.Code = "133";
            ucaf24.Name = "BAĞLI ORTAKLIKLARDAN ALACAKLAR";
            ucaf24.Type = 'A';
            ucaf24.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf24);

            UniformChartOfAccount ucaf25 = new();
            ucaf25.Code = "135";
            ucaf25.Name = "PERSONELDEN ALACAKLAR";
            ucaf25.Type = 'A';
            ucaf25.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf25);

            UniformChartOfAccount ucaf26 = new();
            ucaf26.Code = "136";
            ucaf26.Name = "DİĞER ÇEŞİTLİ ALACAKLAR";
            ucaf26.Type = 'A';
            ucaf26.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf26);

            UniformChartOfAccount ucaf27 = new();
            ucaf27.Code = "137";
            ucaf27.Name = "DİĞER ALACAK SENETLERİ REESKONTU (-)";
            ucaf27.Type = 'A';
            ucaf27.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf27);

            UniformChartOfAccount ucaf28 = new();
            ucaf28.Code = "138";
            ucaf28.Name = "ŞÜPHELİ DİĞER ALACAKLAR";
            ucaf28.Type = 'A';
            ucaf28.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf28);

            UniformChartOfAccount ucaf29 = new();
            ucaf29.Code = "139";
            ucaf29.Name = "ŞÜPHELİ DİĞER ALACAKLAR KARŞILIĞI (-)";
            ucaf29.Type = 'A';
            ucaf29.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf29);

            UniformChartOfAccount ucaf30 = new();
            ucaf30.Code = "15";
            ucaf30.Name = "STOKLAR";
            ucaf30.Type = 'A';
            ucaf30.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf30);

            UniformChartOfAccount ucaf31 = new();
            ucaf31.Code = "150";
            ucaf31.Name = "İLK MADDE VE MALZEME";
            ucaf31.Type = 'A';
            ucaf31.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf31);

            UniformChartOfAccount ucaf32 = new();
            ucaf32.Code = "151";
            ucaf32.Name = "YARI MAMULLER - ÜRETİM";
            ucaf32.Type = 'A';
            ucaf32.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf32);

            UniformChartOfAccount ucaf33 = new();
            ucaf33.Code = "152";
            ucaf33.Name = "MAMÜLLER";
            ucaf33.Type = 'A';
            ucaf33.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf33);

            UniformChartOfAccount ucaf34 = new();
            ucaf34.Code = "153";
            ucaf34.Name = "TİCARİ MALLAR";
            ucaf34.Type = 'A';
            ucaf34.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf34);

            UniformChartOfAccount ucaf35 = new();
            ucaf35.Code = "157";
            ucaf35.Name = "DİĞER STOKLAR";
            ucaf35.Type = 'A';
            ucaf35.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf35);

            UniformChartOfAccount ucaf36 = new();
            ucaf36.Code = "158";
            ucaf36.Name = "STOK DEĞER DÜŞÜKLÜĞÜ KARŞILIĞI (-)";
            ucaf36.Type = 'A';
            ucaf36.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf36);

            UniformChartOfAccount ucaf37 = new();
            ucaf37.Code = "159";
            ucaf37.Name = "VERİLEN SİPARİŞ AVANSLARI";
            ucaf37.Type = 'A';
            ucaf37.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf37);

            UniformChartOfAccount ucaf38 = new();
            ucaf38.Code = "18";
            ucaf38.Name = "GELECEK AYLARA AİT GİDERLER VE GELİR TAHAKKUKLARI";
            ucaf38.Type = 'A';
            ucaf38.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf38);

            UniformChartOfAccount ucaf39 = new();
            ucaf39.Code = "180";
            ucaf39.Name = "GELECEK AYLARA AİT GİDERLER";
            ucaf39.Type = 'A';
            ucaf39.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf39);

            UniformChartOfAccount ucaf40 = new();
            ucaf40.Code = "181";
            ucaf40.Name = "GELİR TAHAKKUKLARI";
            ucaf40.Type = 'A';
            ucaf40.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf40);

            UniformChartOfAccount ucaf41 = new();
            ucaf41.Code = "19";
            ucaf41.Name = "DİĞER DÖNEN VARLIKLAR";
            ucaf41.Type = 'A';
            ucaf41.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf41);

            UniformChartOfAccount ucaf42 = new();
            ucaf42.Code = "191";
            ucaf42.Name = "İNDİRİLECEK KATMA DEĞER VERGİSİ";
            ucaf42.Type = 'A';
            ucaf42.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf42);

            UniformChartOfAccount ucaf43 = new();
            ucaf43.Code = "192";
            ucaf43.Name = "DİĞER KATMA DEĞER VERGİSİ";
            ucaf43.Type = 'A';
            ucaf43.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf43);

            UniformChartOfAccount ucaf44 = new();
            ucaf44.Code = "193";
            ucaf44.Name = "PEŞİN ÖDENEN VERGİLER VE FONLAR";
            ucaf44.Type = 'A';
            ucaf44.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf44);

            UniformChartOfAccount ucaf45 = new();
            ucaf45.Code = "196";
            ucaf45.Name = "PERSONEL AVANSLARI";
            ucaf45.Type = 'A';
            ucaf45.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf45);

            UniformChartOfAccount ucaf46 = new();
            ucaf46.Code = "197";
            ucaf46.Name = "SAYIM VE TESELLÜM NOKSANLARI";
            ucaf46.Type = 'A';
            ucaf46.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf46);

            UniformChartOfAccount ucaf47 = new();
            ucaf47.Code = "198";
            ucaf47.Name = "DİĞER ÇEŞİTLİ DÖNEN VARLIKLAR";
            ucaf47.Type = 'A';
            ucaf47.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf47);

            UniformChartOfAccount ucaf48 = new();
            ucaf48.Code = "199";
            ucaf48.Name = "DİĞER DÖNEN VARLIKLAR KARŞILIĞI (-)";
            ucaf48.Type = 'A';
            ucaf48.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf48);

            UniformChartOfAccount ucaf49 = new();
            ucaf49.Code = "2";
            ucaf49.Name = "DURAN VARLIKLAR";
            ucaf49.Type = 'A';
            ucaf49.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf49);

            UniformChartOfAccount ucaf50 = new();
            ucaf50.Code = "22";
            ucaf50.Name = "TİCARİ ALACAKLAR";
            ucaf50.Type = 'A';
            ucaf50.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf50);

            UniformChartOfAccount ucaf51 = new();
            ucaf51.Code = "220";
            ucaf51.Name = "ALICILAR";
            ucaf51.Type = 'A';
            ucaf51.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf51);

            UniformChartOfAccount ucaf52 = new();
            ucaf52.Code = "221";
            ucaf52.Name = "ALACAK SENETLERİ";
            ucaf52.Type = 'A';
            ucaf52.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf52);

            UniformChartOfAccount ucaf53 = new();
            ucaf53.Code = "222";
            ucaf53.Name = "ALACAK SENETLERİ REESKONTU (-)";
            ucaf53.Type = 'A';
            ucaf53.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf53);

            UniformChartOfAccount ucaf54 = new();
            ucaf54.Code = "226";
            ucaf54.Name = "VERİLEN DEPOZİTO VE TEMİNATLAR";
            ucaf54.Type = 'A';
            ucaf54.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf54);

            UniformChartOfAccount ucaf55 = new();
            ucaf55.Code = "229";
            ucaf55.Name = "ŞÜPHELİ ALACAKLAR KARŞILIĞI (-)";
            ucaf55.Type = 'A';
            ucaf55.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf55);

            UniformChartOfAccount ucaf56 = new();
            ucaf56.Code = "23";
            ucaf56.Name = "DİĞER ALACAKLAR -1";
            ucaf56.Type = 'A';
            ucaf56.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf56);

            UniformChartOfAccount ucaf57 = new();
            ucaf57.Code = "230";
            ucaf57.Name = "ORTAKLARDAN ALACAKLAR";
            ucaf57.Type = 'A';
            ucaf57.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf57);

            UniformChartOfAccount ucaf58 = new();
            ucaf58.Code = "231";
            ucaf58.Name = "İŞTİRAKLERDEN ALACAKLAR";
            ucaf58.Type = 'A';
            ucaf58.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf58);

            UniformChartOfAccount ucaf59 = new();
            ucaf59.Code = "232";
            ucaf59.Name = "BAĞLI ORTAKLIKLARDAN ALACAKLAR";
            ucaf59.Type = 'A';
            ucaf59.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf59);

            UniformChartOfAccount ucaf60 = new();
            ucaf60.Code = "235";
            ucaf60.Name = "PERSONELDEN ALACAKLAR";
            ucaf60.Type = 'A';
            ucaf60.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf60);

            UniformChartOfAccount ucaf61 = new();
            ucaf61.Code = "236";
            ucaf61.Name = "DİĞER ÇEŞİTLİ ALACAKLAR";
            ucaf61.Type = 'A';
            ucaf61.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf61);

            UniformChartOfAccount ucaf62 = new();
            ucaf62.Code = "237";
            ucaf62.Name = "DİĞER ALACAK SENETLERİ REESKONTU (-)";
            ucaf62.Type = 'A';
            ucaf62.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf62);

            UniformChartOfAccount ucaf63 = new();
            ucaf63.Code = "239";
            ucaf63.Name = "ŞÜPHELİ DİĞER ALACAKLAR KARŞILIĞI (-)";
            ucaf63.Type = 'A';
            ucaf63.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf63);

            UniformChartOfAccount ucaf64 = new();
            ucaf64.Code = "24";
            ucaf64.Name = "MALİ DURAN VARLIKLAR";
            ucaf64.Type = 'A';
            ucaf64.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf64);

            UniformChartOfAccount ucaf65 = new();
            ucaf65.Code = "240";
            ucaf65.Name = "BAĞLI MENKUL KIYMETLER";
            ucaf65.Type = 'A';
            ucaf65.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf65);

            UniformChartOfAccount ucaf66 = new();
            ucaf66.Code = "241";
            ucaf66.Name = "BAĞLI MENKUL KIYMETLER DEĞER DÜŞÜKLÜĞÜ KARŞILIĞI (-)";
            ucaf66.Type = 'A';
            ucaf66.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf66);

            UniformChartOfAccount ucaf67 = new();
            ucaf67.Code = "242";
            ucaf67.Name = "İŞTİRAKLER";
            ucaf67.Type = 'A';
            ucaf67.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf67);

            UniformChartOfAccount ucaf68 = new();
            ucaf68.Code = "243";
            ucaf68.Name = "İŞTİRAKLERE SERMAYE TAAHHÜTLERİ (-)";
            ucaf68.Type = 'A';
            ucaf68.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf68);

            UniformChartOfAccount ucaf69 = new();
            ucaf69.Code = "244";
            ucaf69.Name = "İŞTİRAKLER SERMAYE PAYLARI DEĞER DÜŞÜKLÜĞÜ KARŞILIĞI (-)";
            ucaf69.Type = 'A';
            ucaf69.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf69);

            UniformChartOfAccount ucaf70 = new();
            ucaf70.Code = "245";
            ucaf70.Name = "BAĞLI ORTAKLIKLAR";
            ucaf70.Type = 'A';
            ucaf70.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf70);

            UniformChartOfAccount ucaf71 = new();
            ucaf71.Code = "246";
            ucaf71.Name = "BAĞLI ORTAKLIKLARA SERMAYE TAAHHÜTLERİ (-)";
            ucaf71.Type = 'A';
            ucaf71.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf71);

            UniformChartOfAccount ucaf72 = new();
            ucaf72.Code = "247";
            ucaf72.Name = "BAĞLI ORTAKLIKLAR SERMAYE PAYLARI DEĞER DÜŞÜKLÜGÜ KARŞILIĞI (-)";
            ucaf72.Type = 'A';
            ucaf72.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf72);

            UniformChartOfAccount ucaf73 = new();
            ucaf73.Code = "248";
            ucaf73.Name = "DİĞER MALİ DURAN VARLIKLAR";
            ucaf73.Type = 'A';
            ucaf73.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf73);

            UniformChartOfAccount ucaf74 = new();
            ucaf74.Code = "249";
            ucaf74.Name = "DİĞER MALİ DURAN VARLIKLAR KARŞILIĞI (-)";
            ucaf74.Type = 'A';
            ucaf74.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf74);

            UniformChartOfAccount ucaf75 = new();
            ucaf75.Code = "25";
            ucaf75.Name = "MADDİ DURAN VARLIKLAR";
            ucaf75.Type = 'A';
            ucaf75.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf75);

            UniformChartOfAccount ucaf76 = new();
            ucaf76.Code = "250";
            ucaf76.Name = "ARAZİ VE ARSALAR";
            ucaf76.Type = 'A';
            ucaf76.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf76);

            UniformChartOfAccount ucaf77 = new();
            ucaf77.Code = "251";
            ucaf77.Name = "YER ALTI VE YER ÜSTÜ DÜZENLERİ";
            ucaf77.Type = 'A';
            ucaf77.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf77);

            UniformChartOfAccount ucaf78 = new();
            ucaf78.Code = "252";
            ucaf78.Name = "BİNALAR";
            ucaf78.Type = 'A';
            ucaf78.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf78);

            UniformChartOfAccount ucaf79 = new();
            ucaf79.Code = "253";
            ucaf79.Name = "TESİS, MAKİNE VE CİHAZLAR";
            ucaf79.Type = 'A';
            ucaf79.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf79);

            UniformChartOfAccount ucaf80 = new();
            ucaf80.Code = "254";
            ucaf80.Name = "TAŞITLAR";
            ucaf80.Type = 'A';
            ucaf80.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf80);

            UniformChartOfAccount ucaf81 = new();
            ucaf81.Code = "255";
            ucaf81.Name = "DEMİRBAŞLAR";
            ucaf81.Type = 'A';
            ucaf81.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf81);

            UniformChartOfAccount ucaf82 = new();
            ucaf82.Code = "256";
            ucaf82.Name = "DİĞER MADDİ DURAN VARLIKLAR";
            ucaf82.Type = 'A';
            ucaf82.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf82);

            UniformChartOfAccount ucaf83 = new();
            ucaf83.Code = "257";
            ucaf83.Name = "BİRİKMİŞ AMORTİSMANLAR (-)";
            ucaf83.Type = 'A';
            ucaf83.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf83);

            UniformChartOfAccount ucaf84 = new();
            ucaf84.Code = "258";
            ucaf84.Name = "YAPILMAKTA OLAN YATIRIMLAR";
            ucaf84.Type = 'A';
            ucaf84.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf84);

            UniformChartOfAccount ucaf85 = new();
            ucaf85.Code = "259";
            ucaf85.Name = "VERİLEN AVANSLAR";
            ucaf85.Type = 'A';
            ucaf85.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf85);

            UniformChartOfAccount ucaf86 = new();
            ucaf86.Code = "26";
            ucaf86.Name = "MADDİ OLMAYAN DURAN VARLIKLAR";
            ucaf86.Type = 'A';
            ucaf86.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf86);

            UniformChartOfAccount ucaf87 = new();
            ucaf87.Code = "260";
            ucaf87.Name = "HAKLAR";
            ucaf87.Type = 'A';
            ucaf87.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf87);

            UniformChartOfAccount ucaf88 = new();
            ucaf88.Code = "261";
            ucaf88.Name = "ŞEREFİYE";
            ucaf88.Type = 'A';
            ucaf88.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf88);

            UniformChartOfAccount ucaf89 = new();
            ucaf89.Code = "262";
            ucaf89.Name = "KURULUŞ VE ÖRGÜTLENME GİDERLERİ";
            ucaf89.Type = 'A';
            ucaf89.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf89);

            UniformChartOfAccount ucaf90 = new();
            ucaf90.Code = "263";
            ucaf90.Name = "ARAŞTIRMA VE GELİŞTİRME GİDERLERİ";
            ucaf90.Type = 'A';
            ucaf90.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf90);

            UniformChartOfAccount ucaf91 = new();
            ucaf91.Code = "264";
            ucaf91.Name = "ÖZEL MALİYETLER";
            ucaf91.Type = 'A';
            ucaf91.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf91);

            UniformChartOfAccount ucaf92 = new();
            ucaf92.Code = "267";
            ucaf92.Name = "DİĞER MADDİ OLMAYAN DURAN VARLIKLAR";
            ucaf92.Type = 'A';
            ucaf92.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf92);

            UniformChartOfAccount ucaf93 = new();
            ucaf93.Code = "268";
            ucaf93.Name = "BİRİKMİŞ AMORTİSMANLAR (-)";
            ucaf93.Type = 'A';
            ucaf93.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf93);

            UniformChartOfAccount ucaf94 = new();
            ucaf94.Code = "269";
            ucaf94.Name = "VERİLEN AVANSLAR";
            ucaf94.Type = 'A';
            ucaf94.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf94);

            UniformChartOfAccount ucaf95 = new();
            ucaf95.Code = "27";
            ucaf95.Name = "ÖZEL TÜKENMEYE TABİ VARLIKLAR";
            ucaf95.Type = 'A';
            ucaf95.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf95);

            UniformChartOfAccount ucaf96 = new();
            ucaf96.Code = "271";
            ucaf96.Name = "ARAMA GİDERLERİ";
            ucaf96.Type = 'A';
            ucaf96.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf96);

            UniformChartOfAccount ucaf97 = new();
            ucaf97.Code = "272";
            ucaf97.Name = "HAZIRLIK VE GELİŞTİRME GİDERLERİ";
            ucaf97.Type = 'A';
            ucaf97.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf97);

            UniformChartOfAccount ucaf98 = new();
            ucaf98.Code = "277";
            ucaf98.Name = "DİĞER ÖZEL TÜKENMEYE TABİ VARLIKLAR";
            ucaf98.Type = 'A';
            ucaf98.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf98);

            UniformChartOfAccount ucaf99 = new();
            ucaf99.Code = "278";
            ucaf99.Name = "BİRİKMİŞ TÜKENME PAYLARI (-)";
            ucaf99.Type = 'A';
            ucaf99.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf99);

            UniformChartOfAccount ucaf100 = new();
            ucaf100.Code = "279";
            ucaf100.Name = "VERİLEN AVANSLAR";
            ucaf100.Type = 'A';
            ucaf100.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf100);

            UniformChartOfAccount ucaf101 = new();
            ucaf101.Code = "28";
            ucaf101.Name = "GELECEK YILLARA AİT GİDERLER VE GELİR TAHAKKUKLARI";
            ucaf101.Type = 'A';
            ucaf101.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf101);

            UniformChartOfAccount ucaf102 = new();
            ucaf102.Code = "280";
            ucaf102.Name = "GELECEK YILLARA AİT GİDERLER";
            ucaf102.Type = 'A';
            ucaf102.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf102);

            UniformChartOfAccount ucaf103 = new();
            ucaf103.Code = "281";
            ucaf103.Name = "GELİR TAHAKKUKLARI";
            ucaf103.Type = 'A';
            ucaf103.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf103);

            UniformChartOfAccount ucaf104 = new();
            ucaf104.Code = "29";
            ucaf104.Name = "DİĞER DURAN VARLIKLAR";
            ucaf104.Type = 'A';
            ucaf104.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf104);

            UniformChartOfAccount ucaf105 = new();
            ucaf105.Code = "291";
            ucaf105.Name = "GELECEK YILLARDA İNDİRİLECEK KATMA DEĞER VERGİSİ";
            ucaf105.Type = 'A';
            ucaf105.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf105);

            UniformChartOfAccount ucaf106 = new();
            ucaf106.Code = "292";
            ucaf106.Name = "DİĞER KATMA DEĞER VERGİSİ";
            ucaf106.Type = 'A';
            ucaf106.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf106);

            UniformChartOfAccount ucaf107 = new();
            ucaf107.Code = "293";
            ucaf107.Name = "GELECEK YILLAR İHTİYACI STOKLAR";
            ucaf107.Type = 'A';
            ucaf107.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf107);

            UniformChartOfAccount ucaf108 = new();
            ucaf108.Code = "294";
            ucaf108.Name = "ELDEN ÇIKARILACAK STOKLAR VE MADDİ DURAN VARLIKLAR";
            ucaf108.Type = 'A';
            ucaf108.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf108);

            UniformChartOfAccount ucaf109 = new();
            ucaf109.Code = "297";
            ucaf109.Name = "DİĞER ÇEŞİTLİ DURAN VARLIKLAR";
            ucaf109.Type = 'A';
            ucaf109.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf109);

            UniformChartOfAccount ucaf110 = new();
            ucaf110.Code = "298";
            ucaf110.Name = "STOK DEĞER DÜŞÜKLÜĞÜ KARŞILIĞI (-)";
            ucaf110.Type = 'A';
            ucaf110.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf110);

            UniformChartOfAccount ucaf111 = new();
            ucaf111.Code = "299";
            ucaf111.Name = "BİRİKMİŞ AMORTİSMANLAR (-)";
            ucaf111.Type = 'A';
            ucaf111.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf111);

            UniformChartOfAccount ucaf112 = new();
            ucaf112.Code = "3";
            ucaf112.Name = "KISA VADELİ YABANCI KAYNAKLAR";
            ucaf112.Type = 'A';
            ucaf112.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf112);

            UniformChartOfAccount ucaf113 = new();
            ucaf113.Code = "30";
            ucaf113.Name = "MALİ BORÇLAR";
            ucaf113.Type = 'A';
            ucaf113.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf113);

            UniformChartOfAccount ucaf114 = new();
            ucaf114.Code = "300";
            ucaf114.Name = "BANKA KREDİLERİ";
            ucaf114.Type = 'A';
            ucaf114.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf114);

            UniformChartOfAccount ucaf115 = new();
            ucaf115.Code = "303";
            ucaf115.Name = "UZUN VADELİ KREDİLERİN ANAPARA TAKSİTLERİ VE FAİZLERİ";
            ucaf115.Type = 'A';
            ucaf115.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf115);

            UniformChartOfAccount ucaf116 = new();
            ucaf116.Code = "304";
            ucaf116.Name = "TAHVİL ANAPARA BORÇ, TAKSİT VE FAİZLERİ";
            ucaf116.Type = 'A';
            ucaf116.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf116);

            UniformChartOfAccount ucaf117 = new();
            ucaf117.Code = "305";
            ucaf117.Name = "ÇIKARILMIŞ BONOLAR VE SENETLER";
            ucaf117.Type = 'A';
            ucaf117.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf117);

            UniformChartOfAccount ucaf118 = new();
            ucaf118.Code = "306";
            ucaf118.Name = "ÇIKARILMIŞ DİĞER MENKUL KIYMETLER";
            ucaf118.Type = 'A';
            ucaf118.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf118);

            UniformChartOfAccount ucaf119 = new();
            ucaf119.Code = "308";
            ucaf119.Name = "MENKUL KIYMETLER İHRAÇ FARKI (-)";
            ucaf119.Type = 'A';
            ucaf119.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf119);

            UniformChartOfAccount ucaf120 = new();
            ucaf120.Code = "309";
            ucaf120.Name = "DİĞER MALİ BORÇLAR";
            ucaf120.Type = 'A';
            ucaf120.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf120);

            UniformChartOfAccount ucaf121 = new();
            ucaf121.Code = "32";
            ucaf121.Name = "TİCARİ BORÇLAR";
            ucaf121.Type = 'A';
            ucaf121.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf121);

            UniformChartOfAccount ucaf122 = new();
            ucaf122.Code = "320";
            ucaf122.Name = "SATICILAR";
            ucaf122.Type = 'A';
            ucaf122.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf122);

            UniformChartOfAccount ucaf123 = new();
            ucaf123.Code = "321";
            ucaf123.Name = "BORÇ SENETLERİ";
            ucaf123.Type = 'A';
            ucaf123.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf123);

            UniformChartOfAccount ucaf124 = new();
            ucaf124.Code = "322";
            ucaf124.Name = "BORÇ SENETLERİ REESKONTU (-)";
            ucaf124.Type = 'A';
            ucaf124.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf124);

            UniformChartOfAccount ucaf125 = new();
            ucaf125.Code = "326";
            ucaf125.Name = "ALINAN DEPOZİTO VE TEMİNATLAR";
            ucaf125.Type = 'A';
            ucaf125.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf125);

            UniformChartOfAccount ucaf126 = new();
            ucaf126.Code = "329";
            ucaf126.Name = "DİĞER TİCARİ BORÇLAR";
            ucaf126.Type = 'A';
            ucaf126.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf126);

            UniformChartOfAccount ucaf127 = new();
            ucaf127.Code = "33";
            ucaf127.Name = "DİĞER BORÇLAR";
            ucaf127.Type = 'A';
            ucaf127.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf127);

            UniformChartOfAccount ucaf128 = new();
            ucaf128.Code = "331";
            ucaf128.Name = "ORTAKLARA BORÇLAR";
            ucaf128.Type = 'A';
            ucaf128.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf128);

            UniformChartOfAccount ucaf129 = new();
            ucaf129.Code = "332";
            ucaf129.Name = "İŞTİRAKLERE BORÇLAR";
            ucaf129.Type = 'A';
            ucaf129.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf129);

            UniformChartOfAccount ucaf130 = new();
            ucaf130.Code = "333";
            ucaf130.Name = "BAĞLI ORTAKLIKLARA BORÇLAR";
            ucaf130.Type = 'A';
            ucaf130.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf130);

            UniformChartOfAccount ucaf131 = new();
            ucaf131.Code = "335";
            ucaf131.Name = "PERSONELE BORÇLAR";
            ucaf131.Type = 'A';
            ucaf131.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf131);

            UniformChartOfAccount ucaf132 = new();
            ucaf132.Code = "337";
            ucaf132.Name = "DİĞER BORÇ SENETLERİ REESKONTU (-)";
            ucaf132.Type = 'A';
            ucaf132.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf132);

            UniformChartOfAccount ucaf133 = new();
            ucaf133.Code = "339";
            ucaf133.Name = "DİĞER ÇEŞİTLİ BORÇLAR(1)";
            ucaf133.Type = 'A';
            ucaf133.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf133);

            UniformChartOfAccount ucaf134 = new();
            ucaf134.Code = "34";
            ucaf134.Name = "ALINAN AVANSLAR";
            ucaf134.Type = 'A';
            ucaf134.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf134);

            UniformChartOfAccount ucaf135 = new();
            ucaf135.Code = "340";
            ucaf135.Name = "ALINAN SİPARİŞ AVANSLARI";
            ucaf135.Type = 'A';
            ucaf135.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf135);

            UniformChartOfAccount ucaf136 = new();
            ucaf136.Code = "349";
            ucaf136.Name = "ALINAN DİĞER AVANSLAR";
            ucaf136.Type = 'A';
            ucaf136.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf136);

            UniformChartOfAccount ucaf137 = new();
            ucaf137.Code = "36";
            ucaf137.Name = "ÖDENECEK VERGİ VE DİĞER YÜKÜMLÜLÜKLER";
            ucaf137.Type = 'A';
            ucaf137.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf137);

            UniformChartOfAccount ucaf138 = new();
            ucaf138.Code = "360";
            ucaf138.Name = "ÖDENECEK VERGİ VE FONLAR";
            ucaf138.Type = 'A';
            ucaf138.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf138);

            UniformChartOfAccount ucaf139 = new();
            ucaf139.Code = "361";
            ucaf139.Name = "ÖDENECEK SOSYAL GÜVENLİK KESİNTİLERİ";
            ucaf139.Type = 'A';
            ucaf139.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf139);

            UniformChartOfAccount ucaf140 = new();
            ucaf140.Code = "368";
            ucaf140.Name = "VADESİ GEÇMİŞ ERTELENMİŞ VEYA TAKSİTLENDİRİLMİŞ VERGİ VE DİĞER YÜKÜMLÜLÜKLER";
            ucaf140.Type = 'A';
            ucaf140.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf140);

            UniformChartOfAccount ucaf141 = new();
            ucaf141.Code = "369";
            ucaf141.Name = "ÖDENECEK DİĞER YÜKÜMLÜLÜKLER";
            ucaf141.Type = 'A';
            ucaf141.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf141);

            UniformChartOfAccount ucaf142 = new();
            ucaf142.Code = "37";
            ucaf142.Name = "BORÇ VE GİDER KARŞILIKLARI";
            ucaf142.Type = 'A';
            ucaf142.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf142);

            UniformChartOfAccount ucaf143 = new();
            ucaf143.Code = "370";
            ucaf143.Name = "DÖNEM KÂRI VERGİ VE DİĞER YASAL YÜKÜMLÜLÜK KARŞILIKLARI";
            ucaf143.Type = 'A';
            ucaf143.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf143);

            UniformChartOfAccount ucaf144 = new();
            ucaf144.Code = "371";
            ucaf144.Name = "DÖNEM KÂRININ PEŞİN ÖDENEN VERGİ VE DİĞER YÜKÜMLÜLÜKLERİ (-)";
            ucaf144.Type = 'A';
            ucaf144.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf144);

            UniformChartOfAccount ucaf145 = new();
            ucaf145.Code = "372";
            ucaf145.Name = "KIDEM TAZMİNATI KARŞILIĞI";
            ucaf145.Type = 'A';
            ucaf145.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf145);

            UniformChartOfAccount ucaf146 = new();
            ucaf146.Code = "373";
            ucaf146.Name = "MALİYET GİDERLERİ KARŞILIĞI";
            ucaf146.Type = 'A';
            ucaf146.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf146);

            UniformChartOfAccount ucaf147 = new();
            ucaf147.Code = "379";
            ucaf147.Name = "DİĞER BORÇ VE GİDER KARŞILIKLARI";
            ucaf147.Type = 'A';
            ucaf147.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf147);

            UniformChartOfAccount ucaf148 = new();
            ucaf148.Code = "38";
            ucaf148.Name = "GELECEK AYLARA AİT GELİRLER VE GİDER TAHAKKUKLARI";
            ucaf148.Type = 'A';
            ucaf148.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf148);

            UniformChartOfAccount ucaf149 = new();
            ucaf149.Code = "380";
            ucaf149.Name = "GELECEK AYLARA AİT GELİRLER";
            ucaf149.Type = 'A';
            ucaf149.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf149);

            UniformChartOfAccount ucaf150 = new();
            ucaf150.Code = "381";
            ucaf150.Name = "GİDER TAHAKKUKLARI";
            ucaf150.Type = 'A';
            ucaf150.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf150);

            UniformChartOfAccount ucaf151 = new();
            ucaf151.Code = "39";
            ucaf151.Name = "DİĞER KISA VADELİ YABANCI KAYNAKLAR";
            ucaf151.Type = 'A';
            ucaf151.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf151);

            UniformChartOfAccount ucaf152 = new();
            ucaf152.Code = "391";
            ucaf152.Name = "HESAPLANAN KDV";
            ucaf152.Type = 'A';
            ucaf152.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf152);

            UniformChartOfAccount ucaf153 = new();
            ucaf153.Code = "392";
            ucaf153.Name = "DİĞER KDV";
            ucaf153.Type = 'A';
            ucaf153.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf153);

            UniformChartOfAccount ucaf154 = new();
            ucaf154.Code = "398";
            ucaf154.Name = "SAYIM VE TESELLÜM FAZLALARI(1)";
            ucaf154.Type = 'A';
            ucaf154.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf154);

            UniformChartOfAccount ucaf155 = new();
            ucaf155.Code = "399";
            ucaf155.Name = "DİĞER ÇEŞİTLİ YABANCI KAYNAKLAR";
            ucaf155.Type = 'A';
            ucaf155.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf155);

            UniformChartOfAccount ucaf156 = new();
            ucaf156.Code = "4";
            ucaf156.Name = "UZUN VADELİ YABANCI KAYNAKLAR";
            ucaf156.Type = 'A';
            ucaf156.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf156);

            UniformChartOfAccount ucaf157 = new();
            ucaf157.Code = "40";
            ucaf157.Name = "MALİ BORÇLAR";
            ucaf157.Type = 'A';
            ucaf157.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf157);

            UniformChartOfAccount ucaf158 = new();
            ucaf158.Code = "400";
            ucaf158.Name = "BANKA KREDİLERİ";
            ucaf158.Type = 'A';
            ucaf158.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf158);

            UniformChartOfAccount ucaf159 = new();
            ucaf159.Code = "405";
            ucaf159.Name = "ÇIKARILMIŞ TAHVİLLER";
            ucaf159.Type = 'A';
            ucaf159.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf159);

            UniformChartOfAccount ucaf160 = new();
            ucaf160.Code = "407";
            ucaf160.Name = "ÇIKARILMIŞ DİĞER MENKUL KIYMETLER";
            ucaf160.Type = 'A';
            ucaf160.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf160);

            UniformChartOfAccount ucaf161 = new();
            ucaf161.Code = "408";
            ucaf161.Name = "MENKUL KIYMETLER İHRAÇ FARKI (-)";
            ucaf161.Type = 'A';
            ucaf161.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf161);

            UniformChartOfAccount ucaf162 = new();
            ucaf162.Code = "409";
            ucaf162.Name = "DİĞER MALİ BORÇLAR";
            ucaf162.Type = 'A';
            ucaf162.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf162);

            UniformChartOfAccount ucaf163 = new();
            ucaf163.Code = "42";
            ucaf163.Name = "TİCARİ BORÇLAR";
            ucaf163.Type = 'A';
            ucaf163.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf163);

            UniformChartOfAccount ucaf164 = new();
            ucaf164.Code = "420";
            ucaf164.Name = "SATICILAR";
            ucaf164.Type = 'A';
            ucaf164.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf164);

            UniformChartOfAccount ucaf165 = new();
            ucaf165.Code = "421";
            ucaf165.Name = "BORÇ SENETLERİ";
            ucaf165.Type = 'A';
            ucaf165.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf165);

            UniformChartOfAccount ucaf166 = new();
            ucaf166.Code = "422";
            ucaf166.Name = "BORÇ SENETLERİ REESKONTU (-)";
            ucaf166.Type = 'A';
            ucaf166.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf166);

            UniformChartOfAccount ucaf167 = new();
            ucaf167.Code = "426";
            ucaf167.Name = "ALINAN DEPOZİTO VE TEMİNATLAR";
            ucaf167.Type = 'A';
            ucaf167.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf167);

            UniformChartOfAccount ucaf168 = new();
            ucaf168.Code = "429";
            ucaf168.Name = "DİĞER TİCARİ BORÇLAR";
            ucaf168.Type = 'A';
            ucaf168.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf168);

            UniformChartOfAccount ucaf169 = new();
            ucaf169.Code = "43";
            ucaf169.Name = "DİĞER BORÇLAR";
            ucaf169.Type = 'A';
            ucaf169.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf169);

            UniformChartOfAccount ucaf170 = new();
            ucaf170.Code = "431";
            ucaf170.Name = "ORTAKLARA BORÇLAR";
            ucaf170.Type = 'A';
            ucaf170.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf170);

            UniformChartOfAccount ucaf171 = new();
            ucaf171.Code = "432";
            ucaf171.Name = "İŞTİRAKLERE BORÇLAR";
            ucaf171.Type = 'A';
            ucaf171.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf171);

            UniformChartOfAccount ucaf172 = new();
            ucaf172.Code = "433";
            ucaf172.Name = "BAĞLI ORTAKLIKLARA BORÇLAR";
            ucaf172.Type = 'A';
            ucaf172.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf172);

            UniformChartOfAccount ucaf173 = new();
            ucaf173.Code = "437";
            ucaf173.Name = "DİĞER BORÇ SENETLERİ REESKONTU (-)";
            ucaf173.Type = 'A';
            ucaf173.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf173);

            UniformChartOfAccount ucaf174 = new();
            ucaf174.Code = "438";
            ucaf174.Name = "KAMUYA OLAN ERTELENMİŞ VEYA TAKSİTLENDİRİLMİŞ BORÇLAR";
            ucaf174.Type = 'A';
            ucaf174.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf174);

            UniformChartOfAccount ucaf175 = new();
            ucaf175.Code = "439";
            ucaf175.Name = "DİĞER ÇEŞİTLİ BORÇLAR(1)";
            ucaf175.Type = 'A';
            ucaf175.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf175);

            UniformChartOfAccount ucaf176 = new();
            ucaf176.Code = "44";
            ucaf176.Name = "ALINAN AVANSLAR";
            ucaf176.Type = 'A';
            ucaf176.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf176);

            UniformChartOfAccount ucaf177 = new();
            ucaf177.Code = "440";
            ucaf177.Name = "ALINAN SİPARİŞ AVANSLARI";
            ucaf177.Type = 'A';
            ucaf177.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf177);

            UniformChartOfAccount ucaf178 = new();
            ucaf178.Code = "449";
            ucaf178.Name = "ALINAN DİĞER AVANSLAR";
            ucaf178.Type = 'A';
            ucaf178.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf178);

            UniformChartOfAccount ucaf179 = new();
            ucaf179.Code = "47";
            ucaf179.Name = "BORÇ VE GİDER KARŞILIKLARI";
            ucaf179.Type = 'A';
            ucaf179.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf179);

            UniformChartOfAccount ucaf180 = new();
            ucaf180.Code = "472";
            ucaf180.Name = "KIDEM TAZMİNATI KARŞILIĞI";
            ucaf180.Type = 'A';
            ucaf180.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf180);

            UniformChartOfAccount ucaf181 = new();
            ucaf181.Code = "479";
            ucaf181.Name = "DİĞER BORÇ VE GİDER KARŞILIKLARI";
            ucaf181.Type = 'A';
            ucaf181.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf181);

            UniformChartOfAccount ucaf182 = new();
            ucaf182.Code = "48";
            ucaf182.Name = "GELECEK YILLARA AİT GELİRLER VE GİDER TAHAKKUKLARI";
            ucaf182.Type = 'A';
            ucaf182.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf182);

            UniformChartOfAccount ucaf183 = new();
            ucaf183.Code = "480";
            ucaf183.Name = "GELECEK YILLARA AİT GELİRLER";
            ucaf183.Type = 'A';
            ucaf183.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf183);

            UniformChartOfAccount ucaf184 = new();
            ucaf184.Code = "481";
            ucaf184.Name = "GİDER TAHAKKUKLARI";
            ucaf184.Type = 'A';
            ucaf184.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf184);

            UniformChartOfAccount ucaf185 = new();
            ucaf185.Code = "49";
            ucaf185.Name = "DİĞER UZUN VADELİ YABANCI KAYNAKLAR";
            ucaf185.Type = 'A';
            ucaf185.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf185);

            UniformChartOfAccount ucaf186 = new();
            ucaf186.Code = "492";
            ucaf186.Name = "GELECEK YILLARA ERTELENEN VEYA TERKİN EDİLEN KATMA DEĞER VERGİSİ(1)";
            ucaf186.Type = 'A';
            ucaf186.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf186);

            UniformChartOfAccount ucaf187 = new();
            ucaf187.Code = "493";
            ucaf187.Name = "TESİSE KATILMA PAYLARI";
            ucaf187.Type = 'A';
            ucaf187.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf187);

            UniformChartOfAccount ucaf188 = new();
            ucaf188.Code = "499";
            ucaf188.Name = "DİĞER ÇEŞİTLİ UZUN VADELİ YABANCI KAYNAKLAR";
            ucaf188.Type = 'A';
            ucaf188.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf188);

            UniformChartOfAccount ucaf189 = new();
            ucaf189.Code = "5";
            ucaf189.Name = "ÖZ KAYNAKLAR";
            ucaf189.Type = 'A';
            ucaf189.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf189);

            UniformChartOfAccount ucaf190 = new();
            ucaf190.Code = "50";
            ucaf190.Name = "ÖDENMİŞ SERMAYE";
            ucaf190.Type = 'A';
            ucaf190.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf190);

            UniformChartOfAccount ucaf191 = new();
            ucaf191.Code = "500";
            ucaf191.Name = "SERMAYE";
            ucaf191.Type = 'A';
            ucaf191.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf191);

            UniformChartOfAccount ucaf192 = new();
            ucaf192.Code = "501";
            ucaf192.Name = "ÖDENMEMİŞ SERMAYE (-)";
            ucaf192.Type = 'A';
            ucaf192.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf192);

            UniformChartOfAccount ucaf193 = new();
            ucaf193.Code = "52";
            ucaf193.Name = "SERMAYE YEDEKLERİ";
            ucaf193.Type = 'A';
            ucaf193.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf193);

            UniformChartOfAccount ucaf194 = new();
            ucaf194.Code = "520";
            ucaf194.Name = "HİSSE SENETLERİ İHRAÇ PRİMLERİ";
            ucaf194.Type = 'A';
            ucaf194.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf194);

            UniformChartOfAccount ucaf195 = new();
            ucaf195.Code = "521";
            ucaf195.Name = "HİSSE SENEDİ İPTAL KÂRLARI";
            ucaf195.Type = 'A';
            ucaf195.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf195);

            UniformChartOfAccount ucaf196 = new();
            ucaf196.Code = "522";
            ucaf196.Name = "M.D.V. YENİDEN DEĞERLEME ARTIŞLARI";
            ucaf196.Type = 'A';
            ucaf196.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf196);

            UniformChartOfAccount ucaf197 = new();
            ucaf197.Code = "523";
            ucaf197.Name = "İŞTİRAKLER YENİDEN DEĞERLEME ARTIŞLARI";
            ucaf197.Type = 'A';
            ucaf197.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf197);

            UniformChartOfAccount ucaf198 = new();
            ucaf198.Code = "529";
            ucaf198.Name = "DİĞER SERMAYE YEDEKLERİ";
            ucaf198.Type = 'A';
            ucaf198.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf198);

            UniformChartOfAccount ucaf199 = new();
            ucaf199.Code = "54";
            ucaf199.Name = "KÂR YEDEKLERİ";
            ucaf199.Type = 'A';
            ucaf199.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf199);

            UniformChartOfAccount ucaf200 = new();
            ucaf200.Code = "540";
            ucaf200.Name = "YASAL YEDEKLER";
            ucaf200.Type = 'A';
            ucaf200.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf200);

            UniformChartOfAccount ucaf201 = new();
            ucaf201.Code = "541";
            ucaf201.Name = "STATÜ YEDEKLERİ";
            ucaf201.Type = 'A';
            ucaf201.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf201);

            UniformChartOfAccount ucaf202 = new();
            ucaf202.Code = "542";
            ucaf202.Name = "OLAĞANÜSTÜ YEDEKLER";
            ucaf202.Type = 'A';
            ucaf202.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf202);

            UniformChartOfAccount ucaf203 = new();
            ucaf203.Code = "548";
            ucaf203.Name = "DİĞER KÂR YEDEKLERİ";
            ucaf203.Type = 'A';
            ucaf203.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf203);

            UniformChartOfAccount ucaf204 = new();
            ucaf204.Code = "549";
            ucaf204.Name = "ÖZEL FONLAR";
            ucaf204.Type = 'A';
            ucaf204.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf204);

            UniformChartOfAccount ucaf205 = new();
            ucaf205.Code = "57";
            ucaf205.Name = "GEÇMİŞ YILLAR KÂRLARI";
            ucaf205.Type = 'A';
            ucaf205.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf205);

            UniformChartOfAccount ucaf206 = new();
            ucaf206.Code = "570";
            ucaf206.Name = "GEÇMİŞ YILLAR KÂRLARI";
            ucaf206.Type = 'A';
            ucaf206.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf206);

            UniformChartOfAccount ucaf207 = new();
            ucaf207.Code = "58";
            ucaf207.Name = "GEÇMİŞ YILLAR ZARARLARI (-)";
            ucaf207.Type = 'A';
            ucaf207.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf207);

            UniformChartOfAccount ucaf208 = new();
            ucaf208.Code = "580";
            ucaf208.Name = "GEÇMİŞ YILLAR ZARARLARI";
            ucaf208.Type = 'A';
            ucaf208.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf208);

            UniformChartOfAccount ucaf209 = new();
            ucaf209.Code = "59";
            ucaf209.Name = "DÖNEM NET KÂRI (ZARARI)";
            ucaf209.Type = 'A';
            ucaf209.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf209);

            UniformChartOfAccount ucaf210 = new();
            ucaf210.Code = "590";
            ucaf210.Name = "DÖNEM NET KÂRI";
            ucaf210.Type = 'A';
            ucaf210.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf210);

            UniformChartOfAccount ucaf211 = new();
            ucaf211.Code = "591";
            ucaf211.Name = "DÖNEM NET ZARARI (-)";
            ucaf211.Type = 'A';
            ucaf211.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf211);

            UniformChartOfAccount ucaf212 = new();
            ucaf212.Code = "6";
            ucaf212.Name = "GELİR TABLOSU HESAPLARI";
            ucaf212.Type = 'A';
            ucaf212.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf212);

            UniformChartOfAccount ucaf213 = new();
            ucaf213.Code = "60";
            ucaf213.Name = "BRÜT SATIŞLAR";
            ucaf213.Type = 'A';
            ucaf213.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf213);

            UniformChartOfAccount ucaf214 = new();
            ucaf214.Code = "600";
            ucaf214.Name = "YURTİÇİ SATIŞLAR";
            ucaf214.Type = 'A';
            ucaf214.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf214);

            UniformChartOfAccount ucaf215 = new();
            ucaf215.Code = "601";
            ucaf215.Name = "YURTDIŞI SATIŞLAR";
            ucaf215.Type = 'A';
            ucaf215.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf215);

            UniformChartOfAccount ucaf216 = new();
            ucaf216.Code = "602";
            ucaf216.Name = "DİĞER GELİRLER";
            ucaf216.Type = 'A';
            ucaf216.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf216);

            UniformChartOfAccount ucaf217 = new();
            ucaf217.Code = "61";
            ucaf217.Name = "SATIŞ İNDİRİMLERİ (-)";
            ucaf217.Type = 'A';
            ucaf217.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf217);

            UniformChartOfAccount ucaf218 = new();
            ucaf218.Code = "610";
            ucaf218.Name = "SATIŞTAN İADELER (-)";
            ucaf218.Type = 'A';
            ucaf218.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf218);

            UniformChartOfAccount ucaf219 = new();
            ucaf219.Code = "611";
            ucaf219.Name = "SATIŞ İSKONTOLARI (-)";
            ucaf219.Type = 'A';
            ucaf219.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf219);

            UniformChartOfAccount ucaf220 = new();
            ucaf220.Code = "612";
            ucaf220.Name = "DİĞER İNDİRİMLER (-)";
            ucaf220.Type = 'A';
            ucaf220.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf220);

            UniformChartOfAccount ucaf221 = new();
            ucaf221.Code = "62";
            ucaf221.Name = "SATIŞLARIN MALİYETİ (-)";
            ucaf221.Type = 'A';
            ucaf221.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf221);

            UniformChartOfAccount ucaf222 = new();
            ucaf222.Code = "620";
            ucaf222.Name = "SATILAN MAMÜLLER MALİYETİ (-)";
            ucaf222.Type = 'A';
            ucaf222.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf222);

            UniformChartOfAccount ucaf223 = new();
            ucaf223.Code = "621";
            ucaf223.Name = "SATILAN TİCARİ MALLAR MALİYETİ (-)";
            ucaf223.Type = 'A';
            ucaf223.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf223);

            UniformChartOfAccount ucaf224 = new();
            ucaf224.Code = "622";
            ucaf224.Name = "SATILAN HİZMET MALİYETİ (-)";
            ucaf224.Type = 'A';
            ucaf224.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf224);

            UniformChartOfAccount ucaf225 = new();
            ucaf225.Code = "623";
            ucaf225.Name = "DİĞER SATIŞLARIN MALİYETİ (-)";
            ucaf225.Type = 'A';
            ucaf225.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf225);

            UniformChartOfAccount ucaf226 = new();
            ucaf226.Code = "63";
            ucaf226.Name = "FAALİYET GİDERLERİ (-)";
            ucaf226.Type = 'A';
            ucaf226.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf226);

            UniformChartOfAccount ucaf227 = new();
            ucaf227.Code = "630";
            ucaf227.Name = "ARAŞTIRMA VE GELİŞTİRME GİDERLERİ (-)";
            ucaf227.Type = 'A';
            ucaf227.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf227);

            UniformChartOfAccount ucaf228 = new();
            ucaf228.Code = "631";
            ucaf228.Name = "PAZARLAMA SATIŞ VE DAĞITIM GİDERLERİ";
            ucaf228.Type = 'A';
            ucaf228.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf228);

            UniformChartOfAccount ucaf229 = new();
            ucaf229.Code = "632";
            ucaf229.Name = "GENEL YÖNETİM GİDERLERİ (-)";
            ucaf229.Type = 'A';
            ucaf229.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf229);

            UniformChartOfAccount ucaf230 = new();
            ucaf230.Code = "64";
            ucaf230.Name = "DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KÂRLAR";
            ucaf230.Type = 'A';
            ucaf230.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf230);

            UniformChartOfAccount ucaf231 = new();
            ucaf231.Code = "640";
            ucaf231.Name = "İŞTİRAKLERDEN TEMETTÜ GELİRLERİ";
            ucaf231.Type = 'A';
            ucaf231.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf231);

            UniformChartOfAccount ucaf232 = new();
            ucaf232.Code = "641";
            ucaf232.Name = "BAĞLI ORTAKLIKLARDAN TEMETTÜ GELİRLERİ";
            ucaf232.Type = 'A';
            ucaf232.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf232);

            UniformChartOfAccount ucaf233 = new();
            ucaf233.Code = "642";
            ucaf233.Name = "FAİZ GELİRLERİ";
            ucaf233.Type = 'A';
            ucaf233.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf233);

            UniformChartOfAccount ucaf234 = new();
            ucaf234.Code = "643";
            ucaf234.Name = "KOMİSYON GELİRLERİ";
            ucaf234.Type = 'A';
            ucaf234.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf234);

            UniformChartOfAccount ucaf235 = new();
            ucaf235.Code = "644";
            ucaf235.Name = "KONUSU KALMAYAN KARŞILIKLAR";
            ucaf235.Type = 'A';
            ucaf235.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf235);

            UniformChartOfAccount ucaf236 = new();
            ucaf236.Code = "649";
            ucaf236.Name = "FAALİYETLE İLGİLİ DİĞER GELİR VE KÂRLAR";
            ucaf236.Type = 'A';
            ucaf236.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf236);

            UniformChartOfAccount ucaf237 = new();
            ucaf237.Code = "65";
            ucaf237.Name = "DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR (-)";
            ucaf237.Type = 'A';
            ucaf237.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf237);

            UniformChartOfAccount ucaf238 = new();
            ucaf238.Code = "652";
            ucaf238.Name = "REESKONT FAİZ GİDERLERİ (-)(1)";
            ucaf238.Type = 'A';
            ucaf238.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf238);

            UniformChartOfAccount ucaf239 = new();
            ucaf239.Code = "653";
            ucaf239.Name = "KOMİSYON GİDERLERİ (-)";
            ucaf239.Type = 'A';
            ucaf239.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf239);

            UniformChartOfAccount ucaf240 = new();
            ucaf240.Code = "654";
            ucaf240.Name = "KARŞILIK GİDERLERİ (-)";
            ucaf240.Type = 'A';
            ucaf240.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf240);

            UniformChartOfAccount ucaf241 = new();
            ucaf241.Code = "659";
            ucaf241.Name = "DİĞER GİDER VE ZARARLAR (-)";
            ucaf241.Type = 'A';
            ucaf241.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf241);

            UniformChartOfAccount ucaf242 = new();
            ucaf242.Code = "66";
            ucaf242.Name = "FİNANSMAN GİDERLERİ (-)";
            ucaf242.Type = 'A';
            ucaf242.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf242);

            UniformChartOfAccount ucaf243 = new();
            ucaf243.Code = "660";
            ucaf243.Name = "KISA VADELİ BORÇLANMA GİDERLERİ (-)";
            ucaf243.Type = 'A';
            ucaf243.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf243);

            UniformChartOfAccount ucaf244 = new();
            ucaf244.Code = "661";
            ucaf244.Name = "UZUN VADELİ BORÇLANMA GİDERLERİ (-)";
            ucaf244.Type = 'A';
            ucaf244.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf244);

            UniformChartOfAccount ucaf245 = new();
            ucaf245.Code = "67";
            ucaf245.Name = "OLAĞANDIŞI GELİR VE KÂRLAR";
            ucaf245.Type = 'A';
            ucaf245.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf245);

            UniformChartOfAccount ucaf246 = new();
            ucaf246.Code = "671";
            ucaf246.Name = "ÖNCEKİ DÖNEM GELİR VE KÂRLARI";
            ucaf246.Type = 'A';
            ucaf246.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf246);

            UniformChartOfAccount ucaf247 = new();
            ucaf247.Code = "679";
            ucaf247.Name = "DİĞER OLAĞANDIŞI GELİR VE KÂRLAR";
            ucaf247.Type = 'A';
            ucaf247.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf247);

            UniformChartOfAccount ucaf248 = new();
            ucaf248.Code = "68";
            ucaf248.Name = "OLAĞANDIŞI GİDER VE ZARARLAR (-)";
            ucaf248.Type = 'A';
            ucaf248.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf248);

            UniformChartOfAccount ucaf249 = new();
            ucaf249.Code = "680";
            ucaf249.Name = "ÇALIŞMAYAN KISIM GİDER VE ZARARLARI (-)";
            ucaf249.Type = 'A';
            ucaf249.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf249);

            UniformChartOfAccount ucaf250 = new();
            ucaf250.Code = "681";
            ucaf250.Name = "ÖNCEKİ DÖNEM GİDER VE ZARARLARI (-)";
            ucaf250.Type = 'A';
            ucaf250.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf250);

            UniformChartOfAccount ucaf251 = new();
            ucaf251.Code = "689";
            ucaf251.Name = "DİĞER OLAĞANDIŞI GİDER VE ZARARLAR (-)";
            ucaf251.Type = 'A';
            ucaf251.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf251);

            UniformChartOfAccount ucaf252 = new();
            ucaf252.Code = "69";
            ucaf252.Name = "DÖNEM NET KÂRI (ZARARI)";
            ucaf252.Type = 'A';
            ucaf252.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf252);

            UniformChartOfAccount ucaf253 = new();
            ucaf253.Code = "690";
            ucaf253.Name = "DÖNEM KÂRI VEYA ZARARI";
            ucaf253.Type = 'A';
            ucaf253.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf253);

            UniformChartOfAccount ucaf254 = new();
            ucaf254.Code = "691";
            ucaf254.Name = "DÖNEM KÂRI VERGİ VE DİĞER YASAL YÜKÜMLÜLÜK KARŞILIKLARI (-)";
            ucaf254.Type = 'A';
            ucaf254.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf254);

            UniformChartOfAccount ucaf255 = new();
            ucaf255.Code = "692";
            ucaf255.Name = "DÖNEM NET KÂRI VEYA ZARARI";
            ucaf255.Type = 'A';
            ucaf255.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf255);

            UniformChartOfAccount ucaf256 = new();
            ucaf256.Code = "7";
            ucaf256.Name = "MALİYET HESAPLARI (7/A SEÇENEĞİ)";
            ucaf256.Type = 'A';
            ucaf256.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf256);

            UniformChartOfAccount ucaf257 = new();
            ucaf257.Code = "70";
            ucaf257.Name = "MALİYET MUHASEBESİ BAĞLANTI HESAPLARI";
            ucaf257.Type = 'A';
            ucaf257.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf257);

            UniformChartOfAccount ucaf258 = new();
            ucaf258.Code = "700";
            ucaf258.Name = "MALİYET MUHASEBESİ BAĞLANTI HESABI";
            ucaf258.Type = 'A';
            ucaf258.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf258);

            UniformChartOfAccount ucaf259 = new();
            ucaf259.Code = "701";
            ucaf259.Name = "MALİYET MUHASEBESİ YANSITMA HESABI";
            ucaf259.Type = 'A';
            ucaf259.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf259);

            UniformChartOfAccount ucaf260 = new();
            ucaf260.Code = "71";
            ucaf260.Name = "DİREKT İLKMADDE VE MALZEME GİDERLERİ";
            ucaf260.Type = 'A';
            ucaf260.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf260);

            UniformChartOfAccount ucaf261 = new();
            ucaf261.Code = "710";
            ucaf261.Name = "DİREKT İLKMADDE VE MALZEME GİDERLERİ";
            ucaf261.Type = 'A';
            ucaf261.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf261);

            UniformChartOfAccount ucaf262 = new();
            ucaf262.Code = "711";
            ucaf262.Name = "DİREKT İLKMADDE VE MALZEME YANSITMA HESABI";
            ucaf262.Type = 'A';
            ucaf262.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf262);

            UniformChartOfAccount ucaf263 = new();
            ucaf263.Code = "712";
            ucaf263.Name = "DİREKT İLKMADDE VE MALZEME FİYAT FARKI";
            ucaf263.Type = 'A';
            ucaf263.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf263);

            UniformChartOfAccount ucaf264 = new();
            ucaf264.Code = "713";
            ucaf264.Name = "DİREKT İLKMADDE VE MALZEME MİKTAR FARKI";
            ucaf264.Type = 'A';
            ucaf264.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf264);

            UniformChartOfAccount ucaf265 = new();
            ucaf265.Code = "72";
            ucaf265.Name = "DİREKT İŞÇİLİK GİDERLERİ";
            ucaf265.Type = 'A';
            ucaf265.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf265);

            UniformChartOfAccount ucaf266 = new();
            ucaf266.Code = "720";
            ucaf266.Name = "DİREKT İŞÇİLİK GİDERLERİ";
            ucaf266.Type = 'A';
            ucaf266.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf266);

            UniformChartOfAccount ucaf267 = new();
            ucaf267.Code = "721";
            ucaf267.Name = "DİREKT İŞCİLİK GİDERLERİ YANSITMA HESABI";
            ucaf267.Type = 'A';
            ucaf267.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf267);

            UniformChartOfAccount ucaf268 = new();
            ucaf268.Code = "722";
            ucaf268.Name = "DİREKT İŞÇİLİK ÜCRET FARKLARI";
            ucaf268.Type = 'A';
            ucaf268.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf268);

            UniformChartOfAccount ucaf269 = new();
            ucaf269.Code = "723";
            ucaf269.Name = "DİREKT İŞÇİLİK SÜRE (ZAMAN) FARKLARI";
            ucaf269.Type = 'A';
            ucaf269.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf269);

            UniformChartOfAccount ucaf270 = new();
            ucaf270.Code = "73";
            ucaf270.Name = "GENEL ÜRETİM GİDERLERİ";
            ucaf270.Type = 'A';
            ucaf270.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf270);

            UniformChartOfAccount ucaf271 = new();
            ucaf271.Code = "730";
            ucaf271.Name = "GENEL ÜRETİM GİDERLERİ";
            ucaf271.Type = 'A';
            ucaf271.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf271);

            UniformChartOfAccount ucaf272 = new();
            ucaf272.Code = "731";
            ucaf272.Name = "GENEL ÜRETİM GİDERLERİ YANSITMA HESABI";
            ucaf272.Type = 'A';
            ucaf272.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf272);

            UniformChartOfAccount ucaf273 = new();
            ucaf273.Code = "732";
            ucaf273.Name = "GENEL ÜRETİM GİDERLERİ BÜTÇE FARKLARI";
            ucaf273.Type = 'A';
            ucaf273.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf273);

            UniformChartOfAccount ucaf274 = new();
            ucaf274.Code = "733";
            ucaf274.Name = "GENEL ÜRETİM GİDERLERİ VERİMLİLİK FARKLARI";
            ucaf274.Type = 'A';
            ucaf274.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf274);

            UniformChartOfAccount ucaf275 = new();
            ucaf275.Code = "734";
            ucaf275.Name = "GENEL ÜRETİM GİDERLERİ KAPASİTE FARKLARI";
            ucaf275.Type = 'A';
            ucaf275.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf275);

            UniformChartOfAccount ucaf276 = new();
            ucaf276.Code = "74";
            ucaf276.Name = "HİZMET ÜRETİM MALİYETİ";
            ucaf276.Type = 'A';
            ucaf276.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf276);

            UniformChartOfAccount ucaf277 = new();
            ucaf277.Code = "740";
            ucaf277.Name = "HİZMET ÜRETİM MALİYETİ";
            ucaf277.Type = 'A';
            ucaf277.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf277);

            UniformChartOfAccount ucaf278 = new();
            ucaf278.Code = "741";
            ucaf278.Name = "HİZMET ÜRETİM MALİYETİ YANSITMA HESABI";
            ucaf278.Type = 'A';
            ucaf278.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf278);

            UniformChartOfAccount ucaf279 = new();
            ucaf279.Code = "742";
            ucaf279.Name = "HİZMET ÜRETİM MALİYETİ FARK HESAPLARI";
            ucaf279.Type = 'A';
            ucaf279.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf279);

            UniformChartOfAccount ucaf280 = new();
            ucaf280.Code = "75";
            ucaf280.Name = "ARAŞTIRMA VE GELİŞTİRME GİDERLERİ";
            ucaf280.Type = 'A';
            ucaf280.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf280);

            UniformChartOfAccount ucaf281 = new();
            ucaf281.Code = "750";
            ucaf281.Name = "ARAŞTIRMA VE GELİŞTİRME GİDERLERİ";
            ucaf281.Type = 'A';
            ucaf281.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf281);

            UniformChartOfAccount ucaf282 = new();
            ucaf282.Code = "751";
            ucaf282.Name = "ARAŞTIRMA VE GELİŞTİRME GİDERLERİ YANSITMA HESABI";
            ucaf282.Type = 'A';
            ucaf282.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf282);

            UniformChartOfAccount ucaf283 = new();
            ucaf283.Code = "752";
            ucaf283.Name = "ARAŞTIRMA VE GELİŞTİRME GİDER FARKLARI";
            ucaf283.Type = 'A';
            ucaf283.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf283);

            UniformChartOfAccount ucaf284 = new();
            ucaf284.Code = "76";
            ucaf284.Name = "PAZARLAMA SATIŞ YE DAĞITIM GİDERLERİ";
            ucaf284.Type = 'A';
            ucaf284.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf284);

            UniformChartOfAccount ucaf285 = new();
            ucaf285.Code = "760";
            ucaf285.Name = "PAZARLAMA SATIŞ VE DAĞITIM GİDERLERİ";
            ucaf285.Type = 'A';
            ucaf285.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf285);

            UniformChartOfAccount ucaf286 = new();
            ucaf286.Code = "761";
            ucaf286.Name = "PAZARLAMA SATIŞ VE DAĞITIM GİDERLERİ YANSITMA HESABI";
            ucaf286.Type = 'A';
            ucaf286.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf286);

            UniformChartOfAccount ucaf287 = new();
            ucaf287.Code = "762";
            ucaf287.Name = "PAZARLAMA SATIŞ VE DAĞITIM GİDERLERİ FARK HESABI";
            ucaf287.Type = 'A';
            ucaf287.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf287);

            UniformChartOfAccount ucaf288 = new();
            ucaf288.Code = "77";
            ucaf288.Name = "GENEL YÖNETİM GİDERLERİ";
            ucaf288.Type = 'A';
            ucaf288.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf288);

            UniformChartOfAccount ucaf289 = new();
            ucaf289.Code = "770";
            ucaf289.Name = "GENEL YÖNETİM GİDERLERİ";
            ucaf289.Type = 'A';
            ucaf289.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf289);

            UniformChartOfAccount ucaf290 = new();
            ucaf290.Code = "771";
            ucaf290.Name = "GENEL YÖNETİM GİDERLERİ YANSITMA HESABI";
            ucaf290.Type = 'A';
            ucaf290.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf290);

            UniformChartOfAccount ucaf291 = new();
            ucaf291.Code = "772";
            ucaf291.Name = "GENEL YÖNETİM GİDER FARKLARI HESABI";
            ucaf291.Type = 'A';
            ucaf291.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf291);

            UniformChartOfAccount ucaf292 = new();
            ucaf292.Code = "78";
            ucaf292.Name = "FİNANSMAN GİDERLERİ";
            ucaf292.Type = 'A';
            ucaf292.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf292);

            UniformChartOfAccount ucaf293 = new();
            ucaf293.Code = "780";
            ucaf293.Name = "FİNANSMAN GİDERLERİ";
            ucaf293.Type = 'A';
            ucaf293.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf293);

            UniformChartOfAccount ucaf294 = new();
            ucaf294.Code = "781";
            ucaf294.Name = "FİNANSMAN GİDERLERİ YANSITMA HESABI";
            ucaf294.Type = 'A';
            ucaf294.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf294);

            UniformChartOfAccount ucaf295 = new();
            ucaf295.Code = "782";
            ucaf295.Name = "FİNANSMAN GİDERLERİ FARK HESABI";
            ucaf295.Type = 'A';
            ucaf295.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf295);

            UniformChartOfAccount ucaf296 = new();
            ucaf296.Code = "79";
            ucaf296.Name = "GİDER ÇEŞİTLERİ (7/B SEÇENEĞİ)";
            ucaf296.Type = 'A';
            ucaf296.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf296);

            UniformChartOfAccount ucaf297 = new();
            ucaf297.Code = "790";
            ucaf297.Name = "İLKMADDE VE MALZEME GİDERLERİ";
            ucaf297.Type = 'A';
            ucaf297.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf297);

            UniformChartOfAccount ucaf298 = new();
            ucaf298.Code = "791";
            ucaf298.Name = "İŞÇİ ÜCRET VE GİDERLERİ";
            ucaf298.Type = 'A';
            ucaf298.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf298);

            UniformChartOfAccount ucaf299 = new();
            ucaf299.Code = "792";
            ucaf299.Name = "MEMUR ÜCRET VE GİDERLERİ";
            ucaf299.Type = 'A';
            ucaf299.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf299);

            UniformChartOfAccount ucaf300 = new();
            ucaf300.Code = "793";
            ucaf300.Name = "DIŞARIDAN SAĞLANAN FAYDA VE HİZMETLER";
            ucaf300.Type = 'A';
            ucaf300.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf300);

            UniformChartOfAccount ucaf301 = new();
            ucaf301.Code = "794";
            ucaf301.Name = "ÇEŞİTLİ GİDERLER";
            ucaf301.Type = 'A';
            ucaf301.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf301);

            UniformChartOfAccount ucaf302 = new();
            ucaf302.Code = "795";
            ucaf302.Name = "VERGİ, RESİM VE HARÇLAR";
            ucaf302.Type = 'A';
            ucaf302.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf302);

            UniformChartOfAccount ucaf303 = new();
            ucaf303.Code = "796";
            ucaf303.Name = "AMORTİSMANLAR VE TÜKENME PAYLARI";
            ucaf303.Type = 'A';
            ucaf303.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf303);

            UniformChartOfAccount ucaf304 = new();
            ucaf304.Code = "797";
            ucaf304.Name = "FİNANSMAN GİDERLERİ";
            ucaf304.Type = 'A';
            ucaf304.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf304);

            UniformChartOfAccount ucaf305 = new();
            ucaf305.Code = "798";
            ucaf305.Name = "GİDER ÇEŞİTLERİ YANSITMA HESABI";
            ucaf305.Type = 'A';
            ucaf305.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf305);

            UniformChartOfAccount ucaf306 = new();
            ucaf306.Code = "799";
            ucaf306.Name = "ÜRETİM MALİYET HESABI";
            ucaf306.Type = 'A';
            ucaf306.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf306);

            UniformChartOfAccount ucaf307 = new();
            ucaf307.Code = "8";
            ucaf307.Name = "(SERBEST)";
            ucaf307.Type = 'A';
            ucaf307.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf307);

            UniformChartOfAccount ucaf308 = new();
            ucaf308.Code = "9";
            ucaf308.Name = "NAZIM HESAPLAR";
            ucaf308.Type = 'A';
            ucaf308.Id = Guid.NewGuid().ToString();
            uniformChartOfAccounts.Add(ucaf308);           

            await _commandRepository.AddRangeAsync(uniformChartOfAccounts, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateUcafAsync(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);

            UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);

            uniformChartOfAccount.Id = Guid.NewGuid().ToString();

            await _commandRepository.AddAsync(uniformChartOfAccount, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IList<UniformChartOfAccount>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);

            return await _queryRepository.GetAll().OrderBy(p=> p.Code).ToListAsync();
        }

        public async Task<UniformChartOfAccount> GetByCodeAsync(string companyId, string code, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);

            return await _queryRepository.GetFirstByExpiression(p => p.Code == code, cancellationToken);
        }
    }
}
