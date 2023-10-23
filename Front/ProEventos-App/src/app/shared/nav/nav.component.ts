import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsDropdownState } from 'ngx-bootstrap/dropdown';
import { AnimationBuilder } from '@angular/animations';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
isCollapsed=true;
  constructor(private router: Router) { }

  ngOnInit(): void{
  }
  showMenu(): boolean{

    return this.router.url != '/user/login';
  }

}
