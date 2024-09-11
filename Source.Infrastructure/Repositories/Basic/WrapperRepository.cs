using Source.Core.Contracts;
using Source.Core.Contracts.Basic;
using Source.Infrastructure.Infralayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Infrastructure.Repositories.Basic
{
    public class WrapperRepository : IWrapperRepository
    {
        private readonly SqlConnectionFactory _conn;

        public WrapperRepository(SqlConnectionFactory conn)
        {
            _conn = conn;
        }

        private IAccountRepository _account = null!;
        public IAccountRepository Account
        {
            get
            {
                if (_account == null) _account = new AccountRepository(_conn);
                return _account;
            }
        }

        private IAcsFilmRepository _acsFilm = null!;
        public IAcsFilmRepository AcsFilm
        {
            get
            {
                if (_acsFilm == null) _acsFilm = new AcsFilmRepository(_conn);
                return _acsFilm;
            }
        }

        private IDecorationRepository _deco = null!;
        public IDecorationRepository Deco
        {
            get
            {
                if (_deco == null) _deco = new DecorationRepository(_conn);
                return _deco;
            }
        }

        private IExtensionsRepository _extensions = null!;
        public IExtensionsRepository Extensions
        {
            get
            {
                if (_extensions == null) _extensions = new ExtensionsRepository(_conn);
                return _extensions;
            }
        }

        private IKVTWLRepository _kvt = null!;
        public IKVTWLRepository KVTWL
        {
            get
            {
                if (_kvt == null) _kvt = new KVTWLRepository(_conn);
                return _kvt;
            }
        }

        private ILaboratoryRepository _lab = null!;
        public ILaboratoryRepository Lab
        {
            get
            {
                if (_lab == null) _lab = new LaboratoryRepository(_conn);
                return _lab;
            }
        }

        private IQACRepository _qac = null!;
        public IQACRepository Qac
        {
            get
            {
                if (_qac == null) _qac = new QACRepository(_conn);
                return _qac;
            }
        }

        private IReportRepository _report = null!;
        public IReportRepository Report
        {
            get
            {
                if (_report == null) _report = new ReportRepository(_conn);
                return _report;
            }
        }

        

        private ISalesRepository _sales = null!;
        public ISalesRepository Sales
        {
            get
            {
                if (_sales == null) _sales = new SalesRepository(_conn);
                return _sales;
            }
        }


        private IWarehouseFGRepository _wareHouseFG = null!;
        public IWarehouseFGRepository WareHouseFG
        {
            get
            {
                if (_wareHouseFG == null) _wareHouseFG = new WarehouseFGRepository(_conn);
                return _wareHouseFG;
            }
        }
    }
}
