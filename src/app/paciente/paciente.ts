import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { PacienteService } from '../paciente-service';
import { PacienteDto } from '../models/paciente.dto';
import { TipoDocumento } from '../models/tipo-documento.enum';
import { CreatePacienteDto } from '../models/create-paciente.dto';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-paciente',
  styleUrl: './paciente.css',
  templateUrl: './paciente.html',
})
export default class Paciente implements OnInit {
  private pacienteService = inject(PacienteService);
  private fb = inject(FormBuilder).nonNullable;

  protected readonly pacientes = signal<PacienteDto[]>([]);
  protected readonly tiposDocumento = Object.values(TipoDocumento);
  protected readonly errorMessage = signal('');

  protected readonly form = this.fb.group({
    tipoDocumento: [TipoDocumento.Cedula, Validators.required],
    numeroDocumento: ['', [Validators.required, Validators.maxLength(20)]],
    nombrePaciente: ['', [Validators.required, Validators.maxLength(120)]],
    fechaNacimiento: ['', Validators.required],
    correoElectronico: ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
    genero: ['', [Validators.required, Validators.maxLength(20)]],
    direccion: ['', [Validators.required, Validators.maxLength(100)]],
    telefono: ['', [Validators.required, Validators.maxLength(20)]],
    estado: ['Activo', [Validators.required, Validators.maxLength(20)]],
  });

  ngOnInit() {
    this.loadPacientes();
  }

  loadPacientes() {
    this.pacienteService.getPacientes().subscribe((response) => {
      this.pacientes.set(response.data ?? []);
    });
  }

  createPaciente() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.errorMessage.set('');
    const dto: CreatePacienteDto = this.form.getRawValue();

    this.pacienteService.createPaciente(dto).subscribe({
      next: () => {
        this.form.reset({ tipoDocumento: TipoDocumento.Cedula, estado: 'Activo' });
        this.loadPacientes();
      },
      error: (err) => {
        this.errorMessage.set(err.error?.message ?? 'No se pudo crear el paciente');
      },
    });
  }
}
