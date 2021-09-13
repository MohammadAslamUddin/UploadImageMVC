using System.Data;
using System.Data.SqlClient;
using UploadImageMVC.Models;

namespace UploadImageMVC.Gateway
{
    public class ImageGateway : CommonGateway
    {
        public int Save(ImageR image)
        {
            Query = "INSERT INTO Image VALUES(@title, @file)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("title", SqlDbType.VarChar);
            Command.Parameters["title"].Value = image.Title;
            Command.Parameters.Add("file", SqlDbType.VarChar);
            Command.Parameters["file"].Value = image.ImagePath;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public ImageR Search(int id)
        {
            Query = "SELECT * FROM Image WHERE ImageID = " + id;

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            ImageR image = new ImageR();

            while (Reader.Read())
            {
                image.Title = Reader["Title"].ToString();
                image.ImagePath = Reader["ImagePath"].ToString();
            }
            Connection.Close();
            return image;
        }
    }
}