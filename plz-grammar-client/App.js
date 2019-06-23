import React, {Component} from 'react';
import { StyleSheet, Text, View, ActivityIndicator, StatusBar } from 'react-native';
import Problem from './Problem';


export default class App extends Component {
  state = {
    isLoaded: true
  }
  
  render(){
    const { isLoaded } = this.state;
    return (

      <View style={styles.container}>
        <StatusBar hidden={true}></StatusBar>
        {isLoaded ? <Problem/> : 
        
        <View style={styles.loading}>
            <ActivityIndicator/>
            <Text style={styles.loadingText}> Getting the data </Text>
        </View>}
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex:1,
    backgroundColor: '#fff',
  },
  loading:{
    flex:1,
    backgroundColor:'#FDF6AA',
    justifyContent:'center',
    alignItems: 'center',
    paddingTop: 35
  },
  loadingText:{
    
    fontSize:38,
    marginBottom: 100
  },
});
