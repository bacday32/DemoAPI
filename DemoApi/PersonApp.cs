using DemoApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoApi
{
    public class PersonApp
    {

        private SqlConnection conn = new SqlConnection();
        public PersonApp()
        {

            string myConnectionString = @"Data Source=DESKTOP-FLAB826;Initial Catalog=employyee;Persist Security Info=True;User ID=sa;Password=123456";
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (SqlException ex)
            {

            }
        }
        public int SavePerson(Person personToSave)
        {
            String sqlRows = "SELECT COUNT(*) FROM tblperson";
            SqlCommand commandRows = new SqlCommand(sqlRows,conn);
            int id =   (int)commandRows.ExecuteScalar() + 1;

            string sqlString = "INSERT INTO tblperson(firstName,lastName,dateOfBirth) VALUES ('" + personToSave.firstName + "','" + personToSave.lastName + "','" + personToSave.dateOfBirth + "')";
            SqlCommand command = new SqlCommand(sqlString, conn);
            
            command.ExecuteNonQuery();            
            return id;
        }
        public Person GetPerson(int idPerson)
        {
            Person person = new Person();
            SqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tblperson WHERE ID=" + idPerson.ToString();
            SqlCommand command = new SqlCommand(sqlString, conn);
            mySqlReader = command.ExecuteReader();
            if (mySqlReader.Read())
            {
                person.idPerson = mySqlReader.GetInt32(0);
                person.firstName = mySqlReader.GetString(1);
                person.lastName = mySqlReader.GetString(2);
                person.dateOfBirth = mySqlReader.GetString(3);
                return person;
            }
            else
                return null;
        }
        public ArrayList GetPerson()
        {
            ArrayList personArray = new ArrayList();
            
            SqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM tblperson";
            SqlCommand command = new SqlCommand(sqlString, conn);
            mySqlReader = command.ExecuteReader();
            while (mySqlReader.Read())
            {
                Person person = new Person();
                person.idPerson = mySqlReader.GetInt32(0);
                person.firstName = mySqlReader.GetString(1);
                person.lastName = mySqlReader.GetString(2);
                person.dateOfBirth = mySqlReader.GetString(3);
                personArray.Add(person);
            }
            return personArray;
                
        }
        public bool DeletePerson(int idPerson)
        {
            Person person = new Person();
            SqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM tblperson WHERE idPerson = " + idPerson.ToString();
            SqlCommand command = new SqlCommand(sqlString, conn);

            mySqlReader = command.ExecuteReader();
            if (mySqlReader.Read())
            {
                mySqlReader.Close();
                sqlString = "DELETE FROM tblperson WHERE idPerson = " + idPerson.ToString();
                command = new SqlCommand(sqlString, conn);
                command.ExecuteNonQuery();
                return true;
            }
            else return false;
        }
        public bool UpdatePerson(int idPerson,Person personToSave)
        {
            Person person = new Person();
            SqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM tblperson WHERE idPerson = " + idPerson.ToString();
            SqlCommand command = new SqlCommand(sqlString, conn);

            mySqlReader = command.ExecuteReader();
            if (mySqlReader.Read())
            {
                mySqlReader.Close();
                sqlString = "UPDATE tblperson SET firstName='" + personToSave.firstName + "',lastName='" + personToSave.lastName + "',dateOfBirth='" + personToSave.dateOfBirth + "'WHERE idPerson =" + idPerson.ToString();
                command = new SqlCommand(sqlString, conn);
                command.ExecuteNonQuery();
                return true;
            }
            else return false;
        }

    }
}