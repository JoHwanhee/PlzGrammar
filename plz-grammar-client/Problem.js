import React, {Component} from 'react';
import {StyleSheet, Text, View} from 'react-native';
import {LinearGradient} from 'expo';
import { Ionicons} from "@expo/vector-icons";

export default class Problem extends Component {
    render(){
        var answers = ["금새", "금세"];
        var content = "(     ) 집에 도착했다.";
        var iconName = "ios-home";
        var fields = []
        for (let i = 0; i < answers.length; i++) {
            fields.push(
            <View key={i}>
                <Text style={styles.answer}>{answers[i]}</Text>
            </View>
          );
        }
        
      return (
        <LinearGradient colors={["#00C6FB", "#005BEA"]} style={styles.container}>
            <View style={styles.upper}>
            <Ionicons color="white" size={144} name={iconName}></Ionicons>
                <Text style={styles.content}>{content}</Text>
            </View>
            <View style={styles.lower}>
                {fields}
            </View>
        </LinearGradient>
       );
    }
  }
  
  const styles = StyleSheet.create({
    container: {
      flex:1,
    },
    upper: {
        flex:1,
        justifyContent:"center",
        alignItems:"center"
    },
    content:{
        fontSize: 20,
        backgroundColor: "transparent",
        marginTop: 20,
        color:'white',
    },
    lower: {
        flex:1, 
        justifyContent:"center",
        alignItems:"center"
    },
    answer:{
        fontSize: 38,
        backgroundColor: "transparent",
        color:'white',
    },

  });
  