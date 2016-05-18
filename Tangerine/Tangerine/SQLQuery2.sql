create procedure modificar_clientePotencial3

	@idClientePotencial		    [int],
	@nombreClientePotencial  	[varchar](20),	
	@rifClientePotencial	    [varchar](20),
	@emailClientePotencial	    [varchar](50)
   

as
 begin
		UPDATE CLIENTE_POTENCIAL
		SET 
			cli_pot_nombre          = @nombreClientePotencial,
            cli_pot_rif             = @rifClientePotencial,
			cli_pot_email	        = @emailClientePotencial
	
		
			WHERE
			cli_pot_id = @idClientePotencial;	
	
 end;