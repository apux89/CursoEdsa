CREATE OR ALTER PROCEDURE [dbo].[Empleados_GetByFilter]
	
	@Nombre VARCHAR(200) = NULL,
	@Apellidos VARCHAR(200) = NULL,
	@FechaNacimiento DATETIME = NULL,
	@Sexo CHAR(1) = NULL,
	@Salario NUMERIC(25,12) = NULL,
	@Cargo Varchar(100) = NULL,
	--PAGINADO CON ORDENAMIENTO--
    @PageSize int = null,
    @PageIndex int = null, 
    @SortBy varchar(max) = null,
    @Order int = null
    --PAGINADO CON ORDENAMIENTO--
AS
BEGIN
	--PAGINADO CON ORDENAMIENTO--
    IF @PageIndex > 0
    BEGIN
        set @PageIndex = @PageIndex -1
    END
    --PAGINADO CON ORDENAMIENTO--
	
	SELECT
		ID_EMPLEADO
		,NOMBRE
		,APELLIDOS
		,F_NACIMIENTO
		,SEXO
		,CARGO
		,SALARIO
	--PAGINADO CON ORDENAMIENTO--
        ,COUNT(*) OVER() total_records
    --PAGINADO CON ORDENAMIENTO--
	FROM [dbo].[Empleados] 
	
	WHERE 
		(@Nombre IS NULL OR NOMBRE LIKE '%' + @Nombre + '%') AND
		(@Apellidos IS NULL OR APELLIDOS LIKE '%' + @Apellidos + '%') AND
		(@FechaNacimiento IS NULL OR F_NACIMIENTO = @FechaNacimiento) AND
		(@Sexo IS NULL OR SEXO =@Sexo) AND
		(@Salario IS NULL OR SALARIO = @Salario) AND
		(@Cargo IS NULL OR CARGO = @Cargo) 
		
		
		
	ORDER BY
        --POR CADA CAMPO DE LA GRILLA QUE PERMITE ORDERNAR SE LE AGREGA 2 LINEAS PARA EL ORDEN
        	case when @order > 0 and @SortBy = 'NOMBRE' then NOMBRE end desc,
        	case when @order < 0 and @SortBy = 'NOMBRE' then NOMBRE end asc,
        	case when @order > 0 and @SortBy = 'APELLIDOS' then APELLIDOS end desc,
        	case when @order < 0 and @SortBy = 'APELLIDOS' then APELLIDOS end asc,

        -- Y POR ULTIMO EL ORDENAMIENTO POR DEFAULT
        case when @order is null    then  ID_EMPLEADO else null end

        OFFSET 
            case 
                when @PageIndex is not null and @PageSize is not null then            --APLICO PAGINADO
                    (@PageIndex * @PageSize) 
            else
                0                                        --NO APLICO EL PAGINADO
            end 
        rows 
        fetch next 
            case
                when @PageIndex is not null and @PageSize is not null then
                    @PageSize                                --APLICO PAGINADO
                else
                	case 
                		when (select count(*) from [Empleados]) > 0 then 
                    		(select count(*) from [Empleados])    --ESTE SELECT TIENE QUE SER DE LA TABLA PRINCIPAL DE DONDE SALEN LOS DATOS --NO APLICO PAGINADO
                    	else
                    		1
                    end 
            end
        rows only
END
GO
