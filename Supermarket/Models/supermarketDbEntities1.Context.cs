﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Supermarket.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class supermarketDBEntities2 : DbContext
    {
        public supermarketDBEntities2()
            : base("name=supermarketDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bonuri> Bonuri { get; set; }
        public virtual DbSet<Oferte> Oferte { get; set; }
        public virtual DbSet<Producatori> Producatori { get; set; }
        public virtual DbSet<Produs_Bon> Produs_Bon { get; set; }
        public virtual DbSet<Produse> Produse { get; set; }
        public virtual DbSet<Stocuri> Stocuri { get; set; }
        public virtual DbSet<Utilizatori> Utilizatori { get; set; }
    
        public virtual int AddProducator(string nume, string tara)
        {
            var numeParameter = nume != null ?
                new ObjectParameter("Nume", nume) :
                new ObjectParameter("Nume", typeof(string));
    
            var taraParameter = tara != null ?
                new ObjectParameter("Tara", tara) :
                new ObjectParameter("Tara", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddProducator", numeParameter, taraParameter);
        }
    
        public virtual int AddProdus(string nume, string codBare, string categorie, Nullable<int> iDProducator)
        {
            var numeParameter = nume != null ?
                new ObjectParameter("Nume", nume) :
                new ObjectParameter("Nume", typeof(string));
    
            var codBareParameter = codBare != null ?
                new ObjectParameter("CodBare", codBare) :
                new ObjectParameter("CodBare", typeof(string));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            var iDProducatorParameter = iDProducator.HasValue ?
                new ObjectParameter("IDProducator", iDProducator) :
                new ObjectParameter("IDProducator", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddProdus", numeParameter, codBareParameter, categorieParameter, iDProducatorParameter);
        }
    
        public virtual int AddStoc(Nullable<int> cantitate, string unitate, Nullable<System.DateTime> dataAprovizionare, Nullable<System.DateTime> dataExpirare, Nullable<double> pretAchizitie, Nullable<int> iDProdus)
        {
            var cantitateParameter = cantitate.HasValue ?
                new ObjectParameter("Cantitate", cantitate) :
                new ObjectParameter("Cantitate", typeof(int));
    
            var unitateParameter = unitate != null ?
                new ObjectParameter("Unitate", unitate) :
                new ObjectParameter("Unitate", typeof(string));
    
            var dataAprovizionareParameter = dataAprovizionare.HasValue ?
                new ObjectParameter("DataAprovizionare", dataAprovizionare) :
                new ObjectParameter("DataAprovizionare", typeof(System.DateTime));
    
            var dataExpirareParameter = dataExpirare.HasValue ?
                new ObjectParameter("DataExpirare", dataExpirare) :
                new ObjectParameter("DataExpirare", typeof(System.DateTime));
    
            var pretAchizitieParameter = pretAchizitie.HasValue ?
                new ObjectParameter("PretAchizitie", pretAchizitie) :
                new ObjectParameter("PretAchizitie", typeof(double));
    
            var iDProdusParameter = iDProdus.HasValue ?
                new ObjectParameter("IDProdus", iDProdus) :
                new ObjectParameter("IDProdus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddStoc", cantitateParameter, unitateParameter, dataAprovizionareParameter, dataExpirareParameter, pretAchizitieParameter, iDProdusParameter);
        }
    
        public virtual ObjectResult<GetAllProducatori_Result> GetAllProducatori()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProducatori_Result>("GetAllProducatori");
        }
    
        public virtual ObjectResult<GetAllProduse_Result> GetAllProduse()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProduse_Result>("GetAllProduse");
        }
    
        public virtual ObjectResult<spLogIn_Verification_2_Result> spLogIn_Verification_2(string numeUtilizator, string parola)
        {
            var numeUtilizatorParameter = numeUtilizator != null ?
                new ObjectParameter("NumeUtilizator", numeUtilizator) :
                new ObjectParameter("NumeUtilizator", typeof(string));
    
            var parolaParameter = parola != null ?
                new ObjectParameter("Parola", parola) :
                new ObjectParameter("Parola", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spLogIn_Verification_2_Result>("spLogIn_Verification_2", numeUtilizatorParameter, parolaParameter);
        }
    
        public virtual int AddOferta(Nullable<int> idStoc, string motiv, Nullable<int> reducere, Nullable<System.DateTime> dataSfarsire)
        {
            var idStocParameter = idStoc.HasValue ?
                new ObjectParameter("idStoc", idStoc) :
                new ObjectParameter("idStoc", typeof(int));
    
            var motivParameter = motiv != null ?
                new ObjectParameter("motiv", motiv) :
                new ObjectParameter("motiv", typeof(string));
    
            var reducereParameter = reducere.HasValue ?
                new ObjectParameter("reducere", reducere) :
                new ObjectParameter("reducere", typeof(int));
    
            var dataSfarsireParameter = dataSfarsire.HasValue ?
                new ObjectParameter("dataSfarsire", dataSfarsire) :
                new ObjectParameter("dataSfarsire", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddOferta", idStocParameter, motivParameter, reducereParameter, dataSfarsireParameter);
        }
    
        public virtual ObjectResult<GetAllStocks_Result> GetAllStocks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllStocks_Result>("GetAllStocks");
        }
    
        public virtual ObjectResult<Nullable<System.DateTime>> GetExpirationDate(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.DateTime>>("GetExpirationDate", idParameter);
        }
    
        public virtual int AddUser(string username, string password, string type)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", usernameParameter, passwordParameter, typeParameter);
        }
    
        public virtual ObjectResult<string> GetAllProductCodes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetAllProductCodes");
        }
    
        public virtual ObjectResult<string> GetAllUsernames()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetAllUsernames");
        }
    
        public virtual int DeleteProducts(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProducts", idParameter);
        }
    
        public virtual int DeleteStocks(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStocks", idParameter);
        }
    
        public virtual int DeleteStocksAfterProducts(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStocksAfterProducts", idParameter);
        }
    
        public virtual ObjectResult<GetAllProduse2_Result> GetAllProduse2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProduse2_Result>("GetAllProduse2");
        }
    
        public virtual int AddOferta2(Nullable<int> idStoc, string motiv, Nullable<int> reducere, Nullable<System.DateTime> dataSfarsire)
        {
            var idStocParameter = idStoc.HasValue ?
                new ObjectParameter("idStoc", idStoc) :
                new ObjectParameter("idStoc", typeof(int));
    
            var motivParameter = motiv != null ?
                new ObjectParameter("motiv", motiv) :
                new ObjectParameter("motiv", typeof(string));
    
            var reducereParameter = reducere.HasValue ?
                new ObjectParameter("reducere", reducere) :
                new ObjectParameter("reducere", typeof(int));
    
            var dataSfarsireParameter = dataSfarsire.HasValue ?
                new ObjectParameter("dataSfarsire", dataSfarsire) :
                new ObjectParameter("dataSfarsire", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddOferta2", idStocParameter, motivParameter, reducereParameter, dataSfarsireParameter);
        }
    
        public virtual ObjectResult<GetAllOferte_Result> GetAllOferte()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllOferte_Result>("GetAllOferte");
        }
    
        public virtual int DeleteOferta(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteOferta", idParameter);
        }
    
        public virtual int DeleteOfertaAfterProdus(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteOfertaAfterProdus", idParameter);
        }
    
        public virtual int DeleteOfertaAfterStock(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteOfertaAfterStock", idParameter);
        }
    
        public virtual int ModifyNumeProducator(Nullable<int> id, string numeNou)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var numeNouParameter = numeNou != null ?
                new ObjectParameter("numeNou", numeNou) :
                new ObjectParameter("numeNou", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyNumeProducator", idParameter, numeNouParameter);
        }
    
        public virtual int ModifyTaraProducator(Nullable<int> id, string taraNoua)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var taraNouaParameter = taraNoua != null ?
                new ObjectParameter("taraNoua", taraNoua) :
                new ObjectParameter("taraNoua", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyTaraProducator", idParameter, taraNouaParameter);
        }
    
        public virtual ObjectResult<GetAllOferte2_Result> GetAllOferte2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllOferte2_Result>("GetAllOferte2");
        }
    
        public virtual int ModifyCategorieProdus(Nullable<int> id, string categorieNoua)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var categorieNouaParameter = categorieNoua != null ?
                new ObjectParameter("categorieNoua", categorieNoua) :
                new ObjectParameter("categorieNoua", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyCategorieProdus", idParameter, categorieNouaParameter);
        }
    
        public virtual int ModifyNumeProdus(Nullable<int> id, string numeNou)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var numeNouParameter = numeNou != null ?
                new ObjectParameter("numeNou", numeNou) :
                new ObjectParameter("numeNou", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyNumeProdus", idParameter, numeNouParameter);
        }
    
        public virtual ObjectResult<GetAllStocks2_Result> GetAllStocks2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllStocks2_Result>("GetAllStocks2");
        }
    
        public virtual int ModifyCantitateStoc(Nullable<int> id, Nullable<int> cantitate)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var cantitateParameter = cantitate.HasValue ?
                new ObjectParameter("cantitate", cantitate) :
                new ObjectParameter("cantitate", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyCantitateStoc", idParameter, cantitateParameter);
        }
    
        public virtual int ModifyPretStoc(Nullable<int> id, Nullable<double> pret)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var pretParameter = pret.HasValue ?
                new ObjectParameter("pret", pret) :
                new ObjectParameter("pret", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyPretStoc", idParameter, pretParameter);
        }
    
        public virtual int ModifyUnitateStoc(Nullable<int> id, string unitate)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var unitateParameter = unitate != null ?
                new ObjectParameter("unitate", unitate) :
                new ObjectParameter("unitate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyUnitateStoc", idParameter, unitateParameter);
        }
    
        public virtual int ModifyMotivOferta(Nullable<int> id, string motiv)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var motivParameter = motiv != null ?
                new ObjectParameter("motiv", motiv) :
                new ObjectParameter("motiv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyMotivOferta", idParameter, motivParameter);
        }
    
        public virtual int ModifyProcentOferta(Nullable<int> id, Nullable<int> procent)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var procentParameter = procent.HasValue ?
                new ObjectParameter("procent", procent) :
                new ObjectParameter("procent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyProcentOferta", idParameter, procentParameter);
        }
    
        public virtual ObjectResult<GetAllProductsFromCompanySortedByCategory_Result> GetAllProductsFromCompanySortedByCategory(Nullable<int> idCompanie)
        {
            var idCompanieParameter = idCompanie.HasValue ?
                new ObjectParameter("idCompanie", idCompanie) :
                new ObjectParameter("idCompanie", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProductsFromCompanySortedByCategory_Result>("GetAllProductsFromCompanySortedByCategory", idCompanieParameter);
        }
    
        public virtual ObjectResult<GetMaxTotalOnDay_Result> GetMaxTotalOnDay(Nullable<System.DateTime> data)
        {
            var dataParameter = data.HasValue ?
                new ObjectParameter("Data", data) :
                new ObjectParameter("Data", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMaxTotalOnDay_Result>("GetMaxTotalOnDay", dataParameter);
        }
    
        public virtual ObjectResult<GetSumOfUserOfMonth_Result> GetSumOfUserOfMonth(Nullable<int> an, Nullable<int> luna, Nullable<int> idUtilizator)
        {
            var anParameter = an.HasValue ?
                new ObjectParameter("An", an) :
                new ObjectParameter("An", typeof(int));
    
            var lunaParameter = luna.HasValue ?
                new ObjectParameter("Luna", luna) :
                new ObjectParameter("Luna", typeof(int));
    
            var idUtilizatorParameter = idUtilizator.HasValue ?
                new ObjectParameter("idUtilizator", idUtilizator) :
                new ObjectParameter("idUtilizator", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSumOfUserOfMonth_Result>("GetSumOfUserOfMonth", anParameter, lunaParameter, idUtilizatorParameter);
        }
    
        public virtual ObjectResult<SumPricesByCategory_Result> SumPricesByCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SumPricesByCategory_Result>("SumPricesByCategory");
        }
    
        public virtual ObjectResult<GetAllOffersForSum_Result> GetAllOffersForSum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllOffersForSum_Result>("GetAllOffersForSum");
        }
    
        public virtual ObjectResult<GetAllStocksForSum_Result> GetAllStocksForSum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllStocksForSum_Result>("GetAllStocksForSum");
        }
    
        public virtual ObjectResult<GetAllUsers_Result> GetAllUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllUsers_Result>("GetAllUsers");
        }
    }
}
