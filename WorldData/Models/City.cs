using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
    public class City
    {
      private string _countryCode;
      private string _district;
      private int _id;
      private string _name;
      private int _population;

    public City(string countryCode, string district, int id, string name, int population)
    {
      _countryCode = countryCode;
      _district = district;
      _id = id;
      _name = name;
      _population = population;
    }
    public string GetCountryCode()
    {
      return _countryCode;
    }
    public string GetDistrict()
    {
      return _district;
    }
    public int GetID()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetPopulation()
    {
      return _population;
    }
      public static List<City> GetAll()
      {
        List<City> allCity = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string countryCode = rdr.GetString(2);
          string district = rdr.GetString(3);
          int id = rdr.GetInt32(0);
          string name = rdr.GetString(1);
          int population = rdr.GetInt32(4);
          City newCity = new City(countryCode, district, id, name, population);
          allCity.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCity;
    }
  }
}
