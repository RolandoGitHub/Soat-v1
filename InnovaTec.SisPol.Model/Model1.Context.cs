﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InnovaTec.SisPol.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TParametrica> TParametrica { get; set; }
        public virtual DbSet<TParamDetalle> TParamDetalle { get; set; }
        public virtual DbSet<TPuntoVenta> TPuntoVenta { get; set; }
        public virtual DbSet<TCategoria> TCategoria { get; set; }
        public virtual DbSet<TMarca> TMarca { get; set; }
        public virtual DbSet<TModelo> TModelo { get; set; }
        public virtual DbSet<TEstado> TEstado { get; set; }
        public virtual DbSet<TPolizaFor> TPolizaFor { get; set; }
        public virtual DbSet<TMotorizado> TMotorizado { get; set; }
        public virtual DbSet<TPersonal> TPersonal { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; }
    
        public virtual int SISPOL_GENERAR_POLIZA(string p_ccat_codigo, string p_ccat_descripcion, Nullable<int> p_nest_codigo, string p_cest_descripcion, Nullable<int> p_nform_desde, Nullable<int> p_nform_hasta, string p_cpol_formato, Nullable<int> p_npol_desde, Nullable<int> p_npol_hasta, Nullable<System.DateTime> p_d_fecingreso, Nullable<int> p_n_cantidadPolizas, Nullable<int> p_n_diasVigencia, string p_usuariocrea)
        {
            var p_ccat_codigoParameter = p_ccat_codigo != null ?
                new ObjectParameter("P_ccat_codigo", p_ccat_codigo) :
                new ObjectParameter("P_ccat_codigo", typeof(string));
    
            var p_ccat_descripcionParameter = p_ccat_descripcion != null ?
                new ObjectParameter("P_ccat_descripcion", p_ccat_descripcion) :
                new ObjectParameter("P_ccat_descripcion", typeof(string));
    
            var p_nest_codigoParameter = p_nest_codigo.HasValue ?
                new ObjectParameter("P_nest_codigo", p_nest_codigo) :
                new ObjectParameter("P_nest_codigo", typeof(int));
    
            var p_cest_descripcionParameter = p_cest_descripcion != null ?
                new ObjectParameter("P_cest_descripcion", p_cest_descripcion) :
                new ObjectParameter("P_cest_descripcion", typeof(string));
    
            var p_nform_desdeParameter = p_nform_desde.HasValue ?
                new ObjectParameter("P_nform_desde", p_nform_desde) :
                new ObjectParameter("P_nform_desde", typeof(int));
    
            var p_nform_hastaParameter = p_nform_hasta.HasValue ?
                new ObjectParameter("P_nform_hasta", p_nform_hasta) :
                new ObjectParameter("P_nform_hasta", typeof(int));
    
            var p_cpol_formatoParameter = p_cpol_formato != null ?
                new ObjectParameter("P_cpol_formato", p_cpol_formato) :
                new ObjectParameter("P_cpol_formato", typeof(string));
    
            var p_npol_desdeParameter = p_npol_desde.HasValue ?
                new ObjectParameter("P_npol_desde", p_npol_desde) :
                new ObjectParameter("P_npol_desde", typeof(int));
    
            var p_npol_hastaParameter = p_npol_hasta.HasValue ?
                new ObjectParameter("P_npol_hasta", p_npol_hasta) :
                new ObjectParameter("P_npol_hasta", typeof(int));
    
            var p_d_fecingresoParameter = p_d_fecingreso.HasValue ?
                new ObjectParameter("P_d_fecingreso", p_d_fecingreso) :
                new ObjectParameter("P_d_fecingreso", typeof(System.DateTime));
    
            var p_n_cantidadPolizasParameter = p_n_cantidadPolizas.HasValue ?
                new ObjectParameter("P_n_cantidadPolizas", p_n_cantidadPolizas) :
                new ObjectParameter("P_n_cantidadPolizas", typeof(int));
    
            var p_n_diasVigenciaParameter = p_n_diasVigencia.HasValue ?
                new ObjectParameter("P_n_diasVigencia", p_n_diasVigencia) :
                new ObjectParameter("P_n_diasVigencia", typeof(int));
    
            var p_usuariocreaParameter = p_usuariocrea != null ?
                new ObjectParameter("P_usuariocrea", p_usuariocrea) :
                new ObjectParameter("P_usuariocrea", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SISPOL_GENERAR_POLIZA", p_ccat_codigoParameter, p_ccat_descripcionParameter, p_nest_codigoParameter, p_cest_descripcionParameter, p_nform_desdeParameter, p_nform_hastaParameter, p_cpol_formatoParameter, p_npol_desdeParameter, p_npol_hastaParameter, p_d_fecingresoParameter, p_n_cantidadPolizasParameter, p_n_diasVigenciaParameter, p_usuariocreaParameter);
        }
    
        public virtual int SISPOL_GUARDAR_MOTORIZADO(string p_dni, string p_nombres, string p_apepat, string p_apemat, string p_celular, string p_telefono, string p_email, string p_sexo, Nullable<System.DateTime> p_fecasigna, string p_placamoto, string p_usuario, ObjectParameter nmot_codigo, ObjectParameter nper_codigo)
        {
            var p_dniParameter = p_dni != null ?
                new ObjectParameter("p_dni", p_dni) :
                new ObjectParameter("p_dni", typeof(string));
    
            var p_nombresParameter = p_nombres != null ?
                new ObjectParameter("p_nombres", p_nombres) :
                new ObjectParameter("p_nombres", typeof(string));
    
            var p_apepatParameter = p_apepat != null ?
                new ObjectParameter("p_apepat", p_apepat) :
                new ObjectParameter("p_apepat", typeof(string));
    
            var p_apematParameter = p_apemat != null ?
                new ObjectParameter("p_apemat", p_apemat) :
                new ObjectParameter("p_apemat", typeof(string));
    
            var p_celularParameter = p_celular != null ?
                new ObjectParameter("p_celular", p_celular) :
                new ObjectParameter("p_celular", typeof(string));
    
            var p_telefonoParameter = p_telefono != null ?
                new ObjectParameter("p_telefono", p_telefono) :
                new ObjectParameter("p_telefono", typeof(string));
    
            var p_emailParameter = p_email != null ?
                new ObjectParameter("p_email", p_email) :
                new ObjectParameter("p_email", typeof(string));
    
            var p_sexoParameter = p_sexo != null ?
                new ObjectParameter("p_sexo", p_sexo) :
                new ObjectParameter("p_sexo", typeof(string));
    
            var p_fecasignaParameter = p_fecasigna.HasValue ?
                new ObjectParameter("p_fecasigna", p_fecasigna) :
                new ObjectParameter("p_fecasigna", typeof(System.DateTime));
    
            var p_placamotoParameter = p_placamoto != null ?
                new ObjectParameter("p_placamoto", p_placamoto) :
                new ObjectParameter("p_placamoto", typeof(string));
    
            var p_usuarioParameter = p_usuario != null ?
                new ObjectParameter("p_usuario", p_usuario) :
                new ObjectParameter("p_usuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SISPOL_GUARDAR_MOTORIZADO", p_dniParameter, p_nombresParameter, p_apepatParameter, p_apematParameter, p_celularParameter, p_telefonoParameter, p_emailParameter, p_sexoParameter, p_fecasignaParameter, p_placamotoParameter, p_usuarioParameter, nmot_codigo, nper_codigo);
        }
    
        public virtual int SISPOL_GUARDAR_SUPERVISOR(string p_dni, string p_nombres, string p_apepat, string p_apemat, string p_celular, string p_telefono, string p_email, string p_sexo, string p_usuario, ObjectParameter nsup_codigo, ObjectParameter nper_codigo)
        {
            var p_dniParameter = p_dni != null ?
                new ObjectParameter("p_dni", p_dni) :
                new ObjectParameter("p_dni", typeof(string));
    
            var p_nombresParameter = p_nombres != null ?
                new ObjectParameter("p_nombres", p_nombres) :
                new ObjectParameter("p_nombres", typeof(string));
    
            var p_apepatParameter = p_apepat != null ?
                new ObjectParameter("p_apepat", p_apepat) :
                new ObjectParameter("p_apepat", typeof(string));
    
            var p_apematParameter = p_apemat != null ?
                new ObjectParameter("p_apemat", p_apemat) :
                new ObjectParameter("p_apemat", typeof(string));
    
            var p_celularParameter = p_celular != null ?
                new ObjectParameter("p_celular", p_celular) :
                new ObjectParameter("p_celular", typeof(string));
    
            var p_telefonoParameter = p_telefono != null ?
                new ObjectParameter("p_telefono", p_telefono) :
                new ObjectParameter("p_telefono", typeof(string));
    
            var p_emailParameter = p_email != null ?
                new ObjectParameter("p_email", p_email) :
                new ObjectParameter("p_email", typeof(string));
    
            var p_sexoParameter = p_sexo != null ?
                new ObjectParameter("p_sexo", p_sexo) :
                new ObjectParameter("p_sexo", typeof(string));
    
            var p_usuarioParameter = p_usuario != null ?
                new ObjectParameter("p_usuario", p_usuario) :
                new ObjectParameter("p_usuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SISPOL_GUARDAR_SUPERVISOR", p_dniParameter, p_nombresParameter, p_apepatParameter, p_apematParameter, p_celularParameter, p_telefonoParameter, p_emailParameter, p_sexoParameter, p_usuarioParameter, nsup_codigo, nper_codigo);
        }
    }
}
