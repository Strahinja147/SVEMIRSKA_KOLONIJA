namespace SVEMIRSKA_KOLONIJA
{
    using System;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using SVEMIRSKA_KOLONIJA.Mapiranja; // Ispravljeno za tvoj projekat

    public class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();

        // Funkcija na zahtev otvara sesiju
        public static ISession GetSession()
        {
            // Ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        // Konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                // Tvoja Oracle konfiguracija - ostala je nepromenjena
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ShowSql()
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19089;Password=S19089"));

                return Fluently.Configure()
                    .Database(cfg)
                    // Promenjeno KraljevstvoMapiranje u StanovnikMap da pronađe tvoja mapiranja
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StanovnikMap>())
                    .BuildSessionFactory();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
                return null;
            }
        }
    }
}