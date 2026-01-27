import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Alert, ActivityIndicator } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import authApi from '../api/authApi';

const LoginScreen = ({ navigation }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);

  const handleLogin = async () => {
    if (!email || !password) { Alert.alert('Lỗi', 'Nhập email và mật khẩu'); return; }

    setLoading(true);
    try {
      const res = await authApi.login({ email, password });

      // Lưu token
      if (res.accessToken) {
        await AsyncStorage.setItem('accessToken', res.accessToken);
        if (res.user) await AsyncStorage.setItem('user', JSON.stringify(res.user));

        // Chuyển màn hình
        navigation.replace('Home');
      }
    } catch (error) {
      Alert.alert('Thất bại', 'Sai email hoặc mật khẩu');
    } finally {
      setLoading(false);
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>ĐĂNG NHẬP</Text>
      <TextInput style={styles.input} placeholder="Email" value={email} onChangeText={setEmail} autoCapitalize="none"/>
      <TextInput style={styles.input} placeholder="Mật khẩu" value={password} onChangeText={setPassword} secureTextEntry/>

      <TouchableOpacity style={styles.button} onPress={handleLogin} disabled={loading}>
        {loading ? <ActivityIndicator color="#fff"/> : <Text style={styles.btnText}>ĐĂNG NHẬP</Text>}
      </TouchableOpacity>

      <TouchableOpacity onPress={() => navigation.navigate('Register')} style={{marginTop: 20}}>
         <Text style={{color: 'blue', textAlign: 'center'}}>Chưa có tài khoản? Đăng ký</Text>
      </TouchableOpacity>

      <TouchableOpacity onPress={() => navigation.navigate('ForgotPassword')} style={{marginTop: 15}}>
          <Text style={{color: '#1890ff', textAlign: 'center', fontWeight: 'bold'}}>Quên mật khẩu?</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: { flex: 1, padding: 20, justifyContent: 'center', backgroundColor: '#fff' },
  title: { fontSize: 28, fontWeight: 'bold', marginBottom: 20, textAlign: 'center' },
  input: { borderWidth: 1, borderColor: '#ccc', padding: 15, borderRadius: 8, marginBottom: 15 },
  button: { backgroundColor: '#1890ff', padding: 15, borderRadius: 8, alignItems: 'center' },
  btnText: { color: '#fff', fontWeight: 'bold' }
});

export default LoginScreen;