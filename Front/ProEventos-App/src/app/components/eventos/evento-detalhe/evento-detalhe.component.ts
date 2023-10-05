import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit{
  form!: FormGroup;
  get f():any{ return this.form.controls}
  constructor(private fb: FormBuilder){}

  ngOnInit():void{
    this.validation();
  }

  public validation(): void{
    this.form =  this.fb.group({
      local:['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      dataEvento: ['', Validators.required],
      tema: ['',Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.maxLength(120000)]],
      imagemURL:['',[Validators.required, Validators.email]],
      telefone:['', Validators.required],
      email: ['',Validators.required],

    });
  }
  public resertForm(): void{
    this.form.reset();
  }

}
