using SportShop_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportShop_Project.Controllers.api
{
    public class ShoesController : ApiController
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        SportShopDBDataContext dataContax = new SportShopDBDataContext(stringConnection);

        // GET: api/Cloth
        public IHttpActionResult Get()
        {
            try
            {
                List<Shoe> listOfShoes = dataContax.Shoes.ToList();
                if (listOfShoes.Count <= 0) return Ok("there is no data in storage");
                return Ok(listOfShoes);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Cloth/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Shoe requestedId = dataContax.Shoes.First(item => item.Id == id);
                if (requestedId == null) return Ok("there is no such as id");
                return Ok(requestedId);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Cloth
        public IHttpActionResult Post([FromBody] Shoe uploudShoeItem)
        {
            try
            {
                dataContax.Shoes.InsertOnSubmit(uploudShoeItem);
                dataContax.SubmitChanges();
                return Ok(dataContax.Shoes);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Cloth/5
        public IHttpActionResult Put(int id, [FromBody] Shoe newValueOfShoe)
        {
            try
            {
                Shoe shoeItemToChange = dataContax.Shoes.First(item => item.Id == id);
                if (shoeItemToChange == null) return Ok("there is no such as id");
                shoeItemToChange.ShoeType = newValueOfShoe.ShoeType;
                shoeItemToChange.ShoeBrand = newValueOfShoe.ShoeBrand;
                shoeItemToChange.ShoeModel = newValueOfShoe.ShoeModel;
                shoeItemToChange.ShoePrice = newValueOfShoe.ShoePrice;
                shoeItemToChange.ShoeQuentity = newValueOfShoe.ShoeQuentity;
                shoeItemToChange.ShoeInSale = newValueOfShoe.ShoeInSale;
                shoeItemToChange.ShoePicture = newValueOfShoe.ShoePicture;
                dataContax.SubmitChanges();
                return Ok(dataContax.Shoes);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Cloth/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Shoe shoeItem = dataContax.Shoes.First(item => item.Id == id);
                if (shoeItem == null) return Ok("there is no such as id");
                dataContax.Shoes.DeleteOnSubmit(shoeItem);
                dataContax.SubmitChanges();
                return Ok(dataContax.Shoes);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
