export interface ApiResponse<T> {
  resp: boolean;
  message: string;
  data: T | null;
}
