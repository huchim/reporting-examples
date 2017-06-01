SELECT
      Adm_Afectaciones.Tipo_Movimiento
    , Adm_Afectaciones.Metros_Cuadrados
    , Adm_Afectaciones.Precio_Metros_Cuadrados
    , Cat_Areas.Clave AS Clave_Area
    , Fecha
    , No_Cheque
    , Banco
    , Beneficiario
    , Importe
    , Saldo
    , (CAST(Adm_Proyectos.Clave AS VARCHAR(12)) + ' ' + ISNULL(Adm_Proyectos.Letra, '')) as Clave_Proyecto
    , Adm_Obras.Clave as Clave_Obra
    , Cat_Afectaciones.Clave as Clave_Afectacion
    , Adm_Afectaciones.Afectacion_ID
    , Adm_Afectaciones.Obra_ID
    , Adm_Obras.Descripcion as Obra_Descripcion
    , Cat_Afectaciones.Descripcion as Afectacion_Descripcion
    , Adm_Afectaciones.Concepto as Concepto_Cheque
    , Adm_Obras.Proyecto_ID
    , Adm_Afectaciones.Avaluo
    , Adm_Afectaciones.Zona_Derechos_Inmobiliarios_ID
    , ISNULL(Cat_Zonas_Derechos_Inmobiliarios.Nombre,'') as Zona_Derechos_Inmobiliarios
    , ISNULL(Adm_Afectaciones.No_Deposito,'') AS No_Deposito
    , LEFT(Adm_Afectaciones.Clave_Operacion,2) AS Clave_Operacion
    , Adm_Afectaciones.No_Traspaso 
FROM Cat_Residentes_Obras as CRO, Adm_Afectaciones 
INNER JOIN Adm_Obras ON Adm_Afectaciones.Obra_ID = Adm_Obras.Obra_ID AND Adm_Obras.Area_ID = @areaId 
INNER JOIN Cat_Areas ON Cat_Areas.Area_ID = Adm_Obras.Area_ID
INNER JOIN Adm_Proyectos ON Adm_Proyectos.Proyecto_ID = Adm_Obras.Proyecto_ID
LEFT OUTER JOIN Cat_Afectaciones ON Cat_Afectaciones.Afectacion_ID = Adm_Afectaciones.Tipo_Afectacion_ID 
LEFT OUTER JOIN Cat_Zonas_Derechos_Inmobiliarios ON Cat_Zonas_Derechos_Inmobiliarios.Zona_ID = Adm_Afectaciones.Zona_Derechos_Inmobiliarios_ID 
WHERE 1=1 
    %fechaInicial% 
    %fechaFinal% 
    AND CRO.Residente_ID = Adm_Obras.Residente_ID 
ORDER BY Adm_Afectaciones.Fecha, Adm_Afectaciones.Consecutivo