import React, { useState } from 'react';
import {
  View,
  Text,
  TextInput,
  TouchableOpacity,
  StyleSheet,
  Alert,
  ActivityIndicator,
  Keyboard // <--- 1. Đã thêm thư viện bàn phím
} from 'react-native';
import axiosClient from '../api/axiosClient';

const ForgotPasswordScreen = ({ navigation }) => {
  const [email, setEmail] = useState('');
  const [loading, setLoading] = useState(false);

  const handleReset = async () => {
    // 2. Ẩn bàn phím ngay lập tức để tránh lỗi màn hình đỏ (Crash viewState)
    Keyboard.dismiss();

    if (!email) {
      Alert.alert('Lỗi', 'Vui lòng nhập email'); return;
    }

    setLoading(true);
    try {
      console.log("Bắt đầu gửi yêu cầu Reset pass cho email:", email);

      // Gọi API Backend
      // Lưu ý: Gửi string trực tiếp vì Backend nhận [FromBody] string
      await axiosClient.post('/Auth/forgot-password', JSON.stringify(email), {
        headers: { 'Content-Type': 'application/json' }
      });

      // Nếu chạy đến đây là thành công -> Hiện thông báo
      Alert.alert('Đã gửi mail', 'Vui lòng kiểm tra hộp thư (cả mục Spam) để nhận link reset mật khẩu.', [
        { text: 'Về Đăng nhập', onPress: () => navigation.navigate('Login') }
      ]);

    } catch (error) {
      console.log("Lỗi chi tiết:", error);
      Alert.alert('Lỗi', 'Không gửi được email. Vui lòng kiểm tra lại kết nối hoặc Server.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>QUÊN MẬT KHẨU</Text>
      <Text style={styles.desc}>Nhập email đã đăng ký để nhận hướng dẫn.</Text>

      <TextInput
        style={styles.input}
        placeholder="Nhập email của bạn"
        value={email}
        onChangeText={setEmail}
        keyboardType="email-address"
        autoCapitalize="none"
      />

      <TouchableOpacity style={styles.button} onPress={handleReset} disabled={loading}>
        {loading ? <ActivityIndicator color="#fff"/> : <Text style={styles.btnText}>GỬI YÊU CẦU</Text>}
      </TouchableOpacity>

      <TouchableOpacity onPress={() => navigation.goBack()} style={{marginTop: 20}}>
         <Text style={{color: '#666', textAlign: 'center'}}>Quay lại</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: { flex: 1, padding: 20, justifyContent: 'center', backgroundColor: '#fff' },
  title: { fontSize: 24, fontWeight: 'bold', marginBottom: 10, textAlign: 'center', color: '#1890ff' },
  desc: { textAlign: 'center', marginBottom: 30, color: '#666' },
  input: { borderWidth: 1, borderColor: '#ccc', padding: 15, borderRadius: 8, marginBottom: 20 },
  button: { backgroundColor: '#1890ff', padding: 15, borderRadius: 8, alignItems: 'center' },
  btnText: { color: '#fff', fontWeight: 'bold' }
});

export default ForgotPasswordScreen;