import { HttpClient } from '@angular/common/http';
import { inject, Service } from '@angular/core';
import { Observable } from 'rxjs';
import { CreatePacienteDto } from './models/create-paciente.dto';
import { PacienteDto } from './models/paciente.dto';
import { ApiResponse } from './models/response';

@Service()
export class PacienteService {
  private http = inject(HttpClient);

  public getPacientes(): Observable<ApiResponse<PacienteDto[]>> {
    return this.http.get<ApiResponse<PacienteDto[]>>('https://localhost:7000/api/Paciente');
  }

  public createPaciente(dto: CreatePacienteDto): Observable<ApiResponse<PacienteDto>> {
    return this.http.post<ApiResponse<PacienteDto>>('https://localhost:7000/api/Paciente', dto);
  }
}
