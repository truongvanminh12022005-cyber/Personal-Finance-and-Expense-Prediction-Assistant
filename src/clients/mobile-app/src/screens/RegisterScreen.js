import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Alert, ActivityIndicator } from 'react-native';
import authApi from '../api/authApi';

const RegisterScreen = ({ navigation }) => {
  const [fullName, setFullName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [loading, setLoading] = useState(false);

  const handleRegister = async () => {
    // 1. Kiểm tra dữ liệu nhập vào
    if (!fullName || !email || !password) {
      Alert.alert('Lỗi', 'Vui lòng điền đủ thông tin'); return;
    }
    if (password !== confirmPassword) {
      Alert.alert('Lỗi', 'Mật khẩu xác nhận không khớp'); return;
    }

    setLoading(true);
    try {
      // 2. Chuẩn bị dữ liệu gửi lên Server

      const params = {
        fullName: fullName,
        email: email,
        password: password,
        confirmPassword: confirmPassword
      };

      // 3. Gọi API
      await authApi.register(params);

      // 4. Thông báo thành công
      Alert.alert('Thành công', 'Đăng ký thành công!', [
        { text: 'Đăng nhập ngay', onPress: () => navigation.navigate('Login') }
      ]);
    } catch (error) {
      // Lấy thông báo lỗi chi tiết từ Server nếu có
      const message = error.response?.data?.message ||
                      error.response?.data?.title ||
                      'Đăng ký thất bại';
      Alert.alert('Lỗi', message);
      console.log("Register Error:", error.response?.data); // Log ra để xem nếu cần
    } finally {
      setLoading(false);
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>ĐĂNG KÝ</Text>
      <TextInput style={styles.input} placeholder="Họ tên" value={fullName} onChangeText={setFullName} />
      <TextInput style={styles.input} placeholder="Email" value={email} onChangeText={setEmail} keyboardType="email-address" autoCapitalize="none" />
      <TextInput style={styles.input} placeholder="Mật khẩu" value={password} onChangeText={setPassword} secureTextEntry />
      <TextInput style={styles.input} placeholder="Nhập lại mật khẩu" value={confirmPassword} onChangeText={setConfirmPassword} secureTextEntry />

      <TouchableOpacity style={styles.button} onPress={handleRegister} disabled={loading}>
        {loading ? <ActivityIndicator color="#fff"/> : <Text style={styles.btnText}>ĐĂNG KÝ NGAY</Text>}
      </TouchableOpacity>

      <TouchableOpacity onPress={() => navigation.navigate('Login')} style={{marginTop: 20}}>
         <Text style={{color: 'blue', textAlign: 'center'}}>Quay lại đăng nhập</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: { flex: 1, padding: 20, justifyContent: 'center', backgroundColor: '#fff' },
  title: { fontSize: 28, fontWeight: 'bold', marginBottom: 20, textAlign: 'center', color: '#1890ff' },
  input: { borderWidth: 1, borderColor: '#ccc', padding: 15, borderRadius: 8, marginBottom: 15, backgroundColor: '#f9f9f9' },
  button: { backgroundColor: '#28a745', padding: 15, borderRadius: 8, alignItems: 'center' },
  btnText: { color: '#fff', fontWeight: 'bold', fontSize: 16 }
});

export default RegisterScreen;