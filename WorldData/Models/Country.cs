using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
  public class Country
  {
    private int _capital;
    private string _code;
    private string _code2;
    private string _continent;
    private float _gNP;
    private float _gNPOLD;
    private string _governmentForm;
    private string _headOfState;
    private int _indepYear;
    private float _lifeExpectancy;
    private string _localName;
    private string _name;
    private int _population;
    private string _region;
    private float _surfaceArea;

    public Country(
    int capital,
    string code,
    string code2,
    string continent,
    float gNP,
    float gNPOLD,
    string governmentForm,
    string headOfState,
    int indepYear,
    float lifeExpectancy,
    string localName,
    string name,
    int population,
    string region,
    float surfaceArea)
    {
      _capital=capital;
      _code=code;
      _code2=code2;
      _continent=continent;
      _gNP=gNP;
      _gNPOLD=gNPOLD;
      _governmentForm=governmentForm;
      _headOfState=headOfState;
      _indepYear=indepYear;
      _lifeExpectancy=lifeExpectancy;
      _localName=localName;
      _name=name;
      _population=population;
      _region=region;
      _surfaceArea=surfaceArea;
    }
    public int GetCapital(){
      return _capital;
    }
    public string GetCode(){
      return _code;
    }
    public string GetCode2(){
      return _code2;
    }
    public string GetContinent(){
      return _continent;
    }
    public float GetGNP(){
      return _gNP;
    }
    public float GetgPNOLD(){
      return _gNPOLD;
    }  public string GetGovernmentForm(){
        return _governmentForm;
      }
      public string GetheadOfState(){
        return _headOfState;
      }
      public int GetIndepYear(){
        return _indepYear;
      }
      public float GetLifeExpectancy(){
        return _lifeExpectancy;
      }
      public string GetLocalName(){
        return _localName;
      }
      public string GetName(){
        return _name;
      }
      public int GetPopulation(){
        return _population;
      }
      public string GetRegion(){
        return _region;
      }
      public float GetSurfaceArea(){
        return _surfaceArea;
      }
    public static List<Country> GetAll()
    {
      List<Country> allCountry = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int capital= rdr.GetInt32(13);
        string code= rdr.GetString(0);
        string code2= rdr.GetString(14);
        string continent= rdr.GetString(2);
        float gNP=rdr.GetFloat(8);
        float gNPOLD=rdr.GetFloat(9);
        string governmentForm= rdr.GetString(11);
        string headOfState= rdr.GetString(12);
        if (rdr.GetInt16(5)==null)
        {
          int indepYear=0;
        }
        else
        {
          int indepYear=rdr.GetInt16(5);
        }
        float lifeExpectancy=rdr.GetFloat(7);
        string localName= rdr.GetString(10);
        string name= rdr.GetString(1);
        int population= rdr.GetInt32(6);
        string region= rdr.GetString(3);
        float surfaceArea=rdr.GetFloat(4);
        Country newCountry = new Country(
        capital,
        code,
        code2,
        continent,
        gNP,
        gNPOLD,
        governmentForm,
        headOfState,
        indepYear,
        lifeExpectancy,
        localName,
        name,
        population,
        region,
        surfaceArea
        );
        allCountry.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountry;
    }
  }
}
