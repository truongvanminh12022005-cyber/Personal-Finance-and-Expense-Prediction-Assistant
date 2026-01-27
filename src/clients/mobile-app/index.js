import { registerRootComponent } from 'expo';

// Trỏ tới file App.js (nơi chứa code màn hình Login của bạn)
import App from './App';

// Dòng này ĐĂNG KÝ tên App là "main" để sửa cái lỗi màn hình đỏ bạn gặp
registerRootComponent(App);