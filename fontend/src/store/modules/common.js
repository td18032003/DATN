const state = {
    tenantID: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    userID: "",
    employeeID: 1,
    token: null
  }
  
  const mutations = {
    setTenantID(state,val){
      state.tenantID = val;
    },
    setToken(state,val){
      debugger
      state.token = val;
    }
  }
  
  const actions = {
    setTenantID({ commit }, val) {
      commit('setTenantID',val)
    },
    setToken({ commit },val){
      debugger
      commit('setToken',val)
    }
  }
  
  export default {
    namespaced: true,
    state,
    mutations,
    actions
  }