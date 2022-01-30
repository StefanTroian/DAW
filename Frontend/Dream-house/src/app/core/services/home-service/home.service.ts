import { Injectable } from '@angular/core';
import { ApiService } from '../api/api.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private readonly endpoint = 'Home';

  constructor(private apiService: ApiService) { }

  getHomes() {
    return this.apiService.get(this.endpoint);
  }

}
