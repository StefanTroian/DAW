import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Home } from 'src/app/core/interfaces/home';
import { HomeService } from 'src/app/core/services/home-service/home.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private readonly apiUrl = environment.apiUrl;
  
  constructor(private readonly homeService: HomeService) { }

  ngOnInit(): void {
    // this.httpClient.get<Home>(`${this.apiUrl}/Home`).subscribe((data: any) => {
    //   console.log(data)
    // })
    this.homeService.getHomes().subscribe((data: any) => {
      console.log(data);
    })
  }

}
