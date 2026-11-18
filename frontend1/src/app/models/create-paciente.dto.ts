import { TipoDocumento } from './tipo-documento.enum';

export interface CreatePacienteDto {
  tipoDocumento: TipoDocumento;
  numeroDocumento: string;
  nombrePaciente: string;
  fechaNacimiento: string;
  correoElectronico: string;
  genero: string;
  direccion: string;
  telefono: string;
  estado: string;
}
