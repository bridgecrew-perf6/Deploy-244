﻿using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {

        BaseData db = new BaseData(); 

        // GET: api/<AdController>
        [HttpGet]
        public IEnumerable<Anuncios> Get([FromQuery] Anuncios Ad)
        {
            string sql = $"SELECT * FROM anuncios";
            DataTable dt = db.getTable(sql);
            List<Anuncios> usersList = new List<Anuncios>();
            usersList = (from DataRow dr in dt.Rows
                         select new Anuncios()
                         {
                             idanuncio = Convert.ToInt32(dr["idanuncio"]),
                             idusuario = Convert.ToInt32(dr["idusuario"]),
                             titulo = dr["titulo"].ToString(),
                             descripcion = dr["descripcion"].ToString(),
                             puntuacion = Convert.ToInt32(dr["puntuacion"]),
                             direccion = dr["direccion"].ToString(),
                             estado = dr["estado"].ToString(),
                             tipoEstructura = Convert.ToInt32(dr["tipoEstructura"]),
                             valor = Convert.ToInt32(dr["valor"]),
                             fecha = dr["fecha"].ToString(),
                             certificado = dr["certificado"].ToString()

                         }).ToList();

            return usersList;
        }


        // GET api/<AdController>/5
        [HttpGet("{id}")]
        [Route("api/advertisement/{idusuario}")]
        public IEnumerable<Anuncios> GetAd(int id, [FromQuery] Anuncios Ad)
        {
            string sql = $"SELECT * FROM anuncios where idusuario = '{id}'";
            DataTable dt = db.getTable(sql);
            List<Anuncios> usersList = new List<Anuncios>();
            usersList = (from DataRow dr in dt.Rows
                         select new Anuncios()
                         {
                             idanuncio = Convert.ToInt32(dr["idanuncio"]),
                             idusuario = Convert.ToInt32(dr["idusuario"]),
                             titulo = dr["titulo"].ToString(),
                             descripcion = dr["descripcion"].ToString(),
                             puntuacion = Convert.ToInt32(dr["puntuacion"]),
                             direccion = dr["direccion"].ToString(),
                             estado = dr["estado"].ToString(),
                             tipoEstructura = Convert.ToInt32(dr["tipoEstructura"]),
                             valor = Convert.ToInt32(dr["valor"]),
                             fecha = dr["fecha"].ToString(),
                             certificado = dr["certificado"].ToString()

                         }).ToList();

            return usersList;
        }

        // POST api/<AdController>
        [HttpPost]
        public string Post([FromBody] Anuncios Ad)
        {
            //Insertar anuncio
            string sql = "INSERT INTO anuncios (idusuario,titulo,descripcion,puntuacion,direccion,estado,tipoEstructura,valor,fecha,certificado) VALUES ('" + Ad.idusuario + "','" + Ad.titulo + "','" + Ad.descripcion + "','" + Ad.puntuacion + "','" + Ad.direccion + "','" + Ad.estado + "','" + Ad.tipoEstructura + "','" + Ad.valor + "','" + Ad.fecha + "','" + Ad.certificado + "');";
            string result = db.executeSql(sql);
            return result;
        }

        // PUT api/<AdController>/5
        [HttpPut]
        public string Put([FromBody] Anuncios ad)
        {
            //Actualizar anuncio
            string sql = "UPDATE anuncios SET titulo = '" + ad.titulo + "', descripcion = '" + ad.descripcion + "', puntuacion = '" + ad.puntuacion + "', direccion ='" + ad.direccion + "', estado ='" + ad.estado + "', tipoEstructura ='" + ad.tipoEstructura + "', valor ='" + ad.valor + "', fecha ='" + ad.fecha + "', certificado ='" + ad.certificado + "'  WHERE idanuncio = '" + ad.idanuncio + "'";
            string result = db.executeSql(sql);
            return result;
        }

        // DELETE api/<AdController>/5
        [HttpDelete]
        public string Delete([FromBody] Anuncios ad)
        {
            //Eliminar Anuncio
            string sql = $"DELETE FROM anuncios WHERE idanuncio =" + ad.idanuncio;
            string result = db.executeSql(sql);
            return result;
        }
    }
}
