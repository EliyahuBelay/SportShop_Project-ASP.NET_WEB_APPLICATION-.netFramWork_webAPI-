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
    public class PantsController : ApiController
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        SportShopDBDataContext dataContax = new SportShopDBDataContext(stringConnection);

        // GET: api/Cloth
        public IHttpActionResult Get()
        {
            try
            {
                List<Cloth> listOfPants = dataContax.Cloths.Where(item => item.ClothType == "Pants").ToList();
                if (listOfPants.Count <= 0) return Ok("there is no Pants in storage");
                return Ok(listOfPants);
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
                List<Cloth> listOfPants = dataContax.Cloths.Where(item => item.ClothType == "Pants").ToList();
                if (listOfPants.Count <= 0) return Ok("there is no Pants at all as requested");
                Cloth requestedId = listOfPants.First(item => item.Id == id);
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
        public IHttpActionResult Post([FromBody] Cloth uploudClothItem)
        {
            try
            {
                dataContax.Cloths.InsertOnSubmit(uploudClothItem);
                dataContax.SubmitChanges();
                return Ok(dataContax.Cloths);
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
        public IHttpActionResult Put(int id, [FromBody] Cloth newValueOfCloth)
        {
            try
            {
                Cloth clothItemToChange = dataContax.Cloths.First(item => item.Id == id);
                if (clothItemToChange == null) return Ok("there is no such as id");
                clothItemToChange.ClothType = newValueOfCloth.ClothType;
                clothItemToChange.ClothGender = newValueOfCloth.ClothGender;
                clothItemToChange.ClothBrand = newValueOfCloth.ClothBrand;
                clothItemToChange.ClothModel = newValueOfCloth.ClothModel;
                clothItemToChange.ClothPrice = newValueOfCloth.ClothPrice;
                clothItemToChange.ClothQuentity = newValueOfCloth.ClothQuentity;
                clothItemToChange.ClothIsShort = newValueOfCloth.ClothIsShort;
                clothItemToChange.ClothIsDryFit = newValueOfCloth.ClothIsDryFit;
                clothItemToChange.ClothPicture = newValueOfCloth.ClothPicture;
                dataContax.SubmitChanges();
                return Ok(dataContax.Cloths);
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
                List<Cloth> listOfPants = dataContax.Cloths.Where(item => item.ClothType == "Pants").ToList();
                if (listOfPants.Count <= 0) return Ok("there is no Pants in storage");
                Cloth pantsItem = listOfPants.First(item => item.Id == id);
                if (pantsItem == null) return Ok("there is no such as id");
                dataContax.Cloths.DeleteOnSubmit(pantsItem);
                dataContax.SubmitChanges();
                return Ok(dataContax.Cloths);
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
