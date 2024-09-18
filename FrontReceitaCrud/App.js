import React, { useState } from 'react';
import { StyleSheet, Text, View, TextInput, FlatList, TouchableOpacity } from 'react-native';

export default function App() {
  const [nome, setNome] = useState('');
  const [tempoDePreparo, setTempoDePreparo] = useState('');
  const [custoAproximado, setCustoAproximado] = useState('');
  const [data, setData] = useState([]);

  const handleSubmit = () => {
    const newData = { nome, tempoDePreparo, custoAproximado };
    setData([...data, newData]);
    setNome('');
    setTempoDePreparo('');
    setCustoAproximado('');
  };

  const handleDelete = (index) => {
    const newData = [...data];
    newData.splice(index, 1);
    setData(newData);
  };

  return (
    <View style={styles.container}>
      <Text style={{marginTop: 150, color: 'blue', fontWeight: 'bold', fontSize: 30}}>RECEITA APP</Text>
      <View style={styles.form}>
        <TextInput
          style={styles.input}
          placeholder="Nome"
          value={nome}
          onChangeText={(text) => setNome(text)}
        />
        <TextInput
          style={styles.input}
          placeholder="Tempo de preparo"
          value={tempoDePreparo}
          onChangeText={(text) => setTempoDePreparo(text)}
        />
        <TextInput
          style={styles.input}
          placeholder="Custo aproximado"
          value={custoAproximado}
          onChangeText={(text) => setCustoAproximado(text)}
        />
        <TouchableOpacity style={styles.button} onPress={handleSubmit}>
          <Text style={{ color: 'white', fontWeight: 'bold', textAlign: 'center'}}>Salvar</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.buttonAdicionar} onPress={handleSubmit}>
          <Text style={{ color: 'black', fontWeight: 'bold', textAlign: 'center'}}>Adicionar ingrediente</Text>
        </TouchableOpacity>
      </View>
      <FlatList
        data={data}
        renderItem={({ item, index }) => (
          <View style={styles.listItem}>
            <Text>{item.nome}</Text>
            <Text>{item.tempoDePreparo}</Text>
            <Text>{item.custoAproximado}</Text>
            <TouchableOpacity style={styles.deleteButton} onPress={() => handleDelete(index)}>
              <Text>X</Text>
            </TouchableOpacity>
          </View>
        )}
        keyExtractor={(item, index) => index.toString()}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
    transform: [{ scale: 1.3 }]
  },
  form: {
    marginVertical: 20,
  },
  input: {
    height: 40,
    borderColor: 'black',
    borderWidth: 1,
    borderRadius: 10,
    paddingHorizontal: 10,
    marginVertical: 10,
    color: 'black',
  },
  button: {
    backgroundColor: 'green',
    padding: 10,
    borderRadius: 10,
    marginTop: 10
  },
  listItem: {
    padding: 20,
    borderBottomWidth: 1,
    borderBottomColor: 'gray',
  },
  deleteButton: {
    backgroundColor: 'red',
    padding: 10,
    borderRadius: 5,
  },
  buttonAdicionar: {
    backgroundColor: 'yellow',
    padding: 10,
    borderRadius: 10,
    marginTop: 10

  }
});
