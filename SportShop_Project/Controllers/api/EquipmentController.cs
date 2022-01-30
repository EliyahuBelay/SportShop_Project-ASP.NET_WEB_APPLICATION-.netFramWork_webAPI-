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
    public class EquipmentController : ApiController
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        SportShopDBDataContext dataContax = new SportShopDBDataContext(stringConnection);

        // GET: api/Cloth
        public IHttpActionResult Get()
        {
            try
            {
                List<SportEquipment> listOfEquipment = dataContax.SportEquipments.ToList();
                if (listOfEquipment.Count <= 0) return Ok("there is no data in storage");
                return Ok(listOfEquipment);
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
                SportEquipment requestedId = dataContax.SportEquipments.First(item => item.Id == id);
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
        public IHttpActionResult Post([FromBody] SportEquipment uploudSportEquipmentItem)
        {
            try
            {
                dataContax.SportEquipments.InsertOnSubmit(uploudSportEquipmentItem);
                dataContax.SubmitChanges();
                return Ok(dataContax.SportEquipments);
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
        public IHttpActionResult Put(int id, [FromBody] SportEquipment newValueOfSportEquipment)
        {
            try
            {
                SportEquipment SportEquipmentItemToChange = dataContax.SportEquipments.First(item => item.Id == id);
                if (SportEquipmentItemToChange == null) return Ok("there is no such as id");
                SportEquipmentItemToChange.SportType = newValueOfSportEquipment.SportType;
                SportEquipmentItemToChange.EquipmentName = newValueOfSportEquipment.EquipmentName;
                SportEquipmentItemToChange.EquipmentCompany = newValueOfSportEquipment.EquipmentCompany;
                SportEquipmentItemToChange.EquipmentPrice = newValueOfSportEquipment.EquipmentPrice;
                SportEquipmentItemToChange.EquipmentQuentity = newValueOfSportEquipment.EquipmentQuentity;
                SportEquipmentItemToChange.SportClubId = newValueOfSportEquipment.SportClubId;
                SportEquipmentItemToChange.EquipmentPicture = newValueOfSportEquipment.EquipmentPicture;
                dataContax.SubmitChanges();
                return Ok(dataContax.SportEquipments);
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
                SportEquipment SportEquipmentItem = dataContax.SportEquipments.First(item => item.Id == id);
                if (SportEquipmentItem == null) return Ok("there is no such as id");
                dataContax.SportEquipments.DeleteOnSubmit(SportEquipmentItem);
                dataContax.SubmitChanges();
                return Ok(dataContax.SportEquipments);
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

